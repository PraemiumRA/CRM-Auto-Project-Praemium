using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using ProjectConfiguration;

namespace BLL
{
    /// <summary>
    /// Depend on entered file extension is handling appropriate way.
    /// </summary>
    class StoreData
    {
        IStore storeData;
        List<long> fileList;
        int tempCount;
        public ParallelOptions ParOptions { get; set; }
        public DirectoryInfo JsonDirectory { get; set; }
        public int TaskCount { get; set; }
        public ObservableCollection<string> collection = new ObservableCollection<string>();

        List<Task> tasks = new List<Task>();
        System.Timers.Timer timeToAction;
        AppConfiguration appConfiguration = AppConfiguration.GetInstance;

        public StoreData(DirectoryInfo jsonPath)
        {
            this.JsonDirectory = jsonPath;
            collection.CollectionChanged += Collection_CollectionChanged;
            ConfigurateStore();
            timeToAction = new System.Timers.Timer(1000);
            timeToAction.Elapsed += (sender, e) => StartAction();
        }
        /// <summary>
        /// Is configurating count of tasks depends on processor core count. 
        /// </summary>
        private void ConfigurateStore()
        {
            int prcent = appConfiguration.GetPrecntOfMachineCore;
            int processorCount = Environment.ProcessorCount;

            ParOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = (processorCount * prcent) / 100
            };

            TaskCount = ParOptions.MaxDegreeOfParallelism == 1 ? 2 : (int)((1.3) * ParOptions.MaxDegreeOfParallelism);
        }
        /// <summary>
        /// All files collection's changed handle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                tasks.Add(new Task(() => Store(e.NewItems[0])));
            }
            timeToAction.Start();
        }

        /// <summary>
        /// File handling switcher.
        /// </summary>
        /// <param name="paths"></param>
        private void Store(object paths)
        {
            string path = paths as string;

            if (Path.GetExtension(path) == ".csv")
            {
                storeData = new ReadFromCsv(path, JsonDirectory.ToString());
            }
            else if (Path.GetExtension(path) == ".xml")
            {
                storeData = new ReadFromXml(path, JsonDirectory.ToString());
            }

            TeamMemberProjectBLL store = new TeamMemberProjectBLL(storeData);

            collection.Remove(path);
        }
        /// <summary>
        /// Is colculating count of tasks.
        /// </summary>
        /// <returns></returns>
        private int ColculateCountOfTasks()
        {
            tempCount = 0;
            fileList = new List<long>();

            if (tasks.Count < TaskCount)
            {
                tempCount = tasks.Count;
            }
            else
                tempCount = TaskCount;

            long fileLength = 0;
            for (int i = 0; i < tempCount; i++)
            {
                if (!File.Exists(collection[i]))
                {
                    collection.Remove(collection[i]);
                }
                else
                {
                    fileLength = (new FileInfo(collection[i])).Length;
                    fileList.Add(fileLength);
                }
            }
            long division = 0;

            if (!(fileList.Count == 0 || fileList.Count == 1))
            {
                division = fileList.Max() / fileList.Min();
                if (division > 4)
                {
                    tempCount++;
                }
            }

            return tempCount;
        }
        /// <summary>
        /// Is starting to handle files.
        /// </summary>
        public void StartAction()
        {
            if (tasks.Count == 0) return;

            tempCount = ColculateCountOfTasks();

            Task[] taskArray = new Task[tempCount];
            int index = 0;
            for (int i = 0; i < tempCount; i++)
            {
                taskArray[index] = tasks[i];
                index++;
            }

            Parallel.Invoke(
                ParOptions,
                () =>
                    {
                        for (int i = 0; i < tempCount; i++)
                        {
                            taskArray[i].Start();
                        }
                    }
                );

            tasks.RemoveRange(0, tempCount);
        }

    }
}
