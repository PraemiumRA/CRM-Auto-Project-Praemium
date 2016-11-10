using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BLL
{
    public class FolderWatcher 
    {
        DirectoryInfo directory;
        DirectoryInfo jsonDirectory;
        FileSystemWatcher watcher;
        StoreData   storeData;

        public DirectoryInfo Directory
        {
            get { return this.directory; }
            set
            {
                if (value.Exists)
                {
                    this.directory = value;
                }
            }
        }

        //
        public DirectoryInfo JsonDirectory
        {
            get { return this.jsonDirectory; }
            set
            {
                if (value.Exists)
                {
                    this.jsonDirectory = value;
                }
            }
        }

        public FolderWatcher()
        {

        }

        public FolderWatcher(string path)
        {
            this.Directory = new DirectoryInfo(path);
            this.storeData = new StoreData();
            
        }

        //
        public FolderWatcher(string path, string jsonPath)
        {
            this.Directory = new DirectoryInfo(path);
            this.JsonDirectory = new DirectoryInfo(jsonPath);
            this.storeData = new StoreData(JsonDirectory);
        }

        public void Run()
        {
            watcher = new FileSystemWatcher()
            {
                Path = this.Directory.FullName,
                IncludeSubdirectories = true
            };
                       
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.EnableRaisingEvents = true;
        }

        //Hundel for Delete
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //TODO: Will be work whene file in directory will deleted.
        }

        //Hundel for Create
        private async void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string extension = Path.GetExtension(e.FullPath);
            if (extension.Equals(".xml") || extension.Equals(".csv"))
            {
                await Task.Factory.StartNew(() => { MessageBox.Show("Create: " + e.Name); });
                storeData.collection.Add(e.FullPath);
            }
        }
               
    }
}
