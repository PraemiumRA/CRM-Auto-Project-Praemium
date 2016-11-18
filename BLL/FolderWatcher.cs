using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProjectConfiguration;
using Logging;

namespace BLL
{
    public class FolderWatcher 
    {
        DirectoryInfo directory;
        DirectoryInfo jsonDirectory;
        FileSystemWatcher watcher;
        StoreData   storeData;
        AppConfiguration appConfiguration = AppConfiguration.GetInstance;

        public DirectoryInfo Directory
        {
            get { return this.directory; }
            set { this.directory = value; }
            
        }
        public DirectoryInfo JsonDirectory
        {
            get { return this.jsonDirectory; }
            set { this.jsonDirectory = value; }
           
        }
          
        public FolderWatcher()
        {
            this.Directory = new DirectoryInfo(appConfiguration.GetToMnitorDirectory); //new DirectoryInfo(path);
            this.JsonDirectory = new DirectoryInfo(appConfiguration.JsonCreationDirectory); //new DirectoryInfo(jsonPath);
            this.storeData = new StoreData(JsonDirectory);
                       
        }
        
        public void Run()
        {
            //MessageBox.Show(this.Directory.FullName);
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
            Logger.DoLogging(LogType.Delete, null, "File was deleted from monitoring directory.");
        }

        //Hundel for Create
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string extension = Path.GetExtension(e.FullPath);
            if (extension.Equals(".xml") || extension.Equals(".csv"))
            {
                Logger.DoLogging(LogType.Creation, null, $"{e.Name} was created.");
                storeData.collection.Add(e.FullPath);
            }
        }
               
    }
}
