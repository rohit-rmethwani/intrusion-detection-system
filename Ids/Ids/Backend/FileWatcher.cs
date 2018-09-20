using System;
using System.IO;
using System.Security.Permissions;

namespace Backend
{
    public class Watcher
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private static LogGenerater log = new LogGenerater();
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Please enter the correct path!");
                }
                else
                {
                    path = value;
                }
            }
        }

        /*
         *This method starts the FileWatcher. 
         * @param: Nothing.
         * @returns: Nothing.
         */
        public void StartWatcher()
        {
            watcher.EnableRaisingEvents = true;
        }

        /*
         * This method stops the FileWatcher.
         * @param:Nothing.
         * @returns:Nothing.
         */ 
        public void StopWatcher()
        {
            watcher.EnableRaisingEvents = false;
        }

        /*
         *This method initializes all the events.
         * @param:Nothing.
         * @returns:Nothing.
         */
        public void InitializeEvents()
        {
            // Adding event handlers.
            watcher.Changed += new FileSystemEventHandler(OnFileChanged);
            watcher.Created += new FileSystemEventHandler(OnFileChanged);
            watcher.Deleted += new FileSystemEventHandler(OnFileChanged);
            watcher.Renamed += new RenamedEventHandler(OnFileRenamed);
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        }

        /*
         * This method initializes the Path for the directory/file to be watched.
         * @param:Nothing.
         * @returns:Nothing.
         */ 
        public void InitializePath()
        {
            Console.WriteLine("Enter the path:");
            Path = Console.ReadLine();
            watcher.Path = Path;
        }

        // Define the event handlers.
        private static void OnFileChanged(object source, FileSystemEventArgs e)
        {
            
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                log.GenerateLog("File created: " + e.FullPath + " by " + Environment.UserName);
                Console.WriteLine("File created: " + e.FullPath + " by " + Environment.UserName);

            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                log.GenerateLog("File changed: " + e.FullPath + " by " + Environment.UserName);
                Console.WriteLine("File Changed: " + e.FullPath + " by " + Environment.UserName);
                Console.WriteLine("Last Accessed time:" + DateTime.Now + " by " + Environment.UserName);
            }
            else
            {
                log.GenerateLog("File: " + e.FullPath + " " + e.ChangeType + " by " + Environment.UserName);
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType + " by " + Environment.UserName);
            }
        }

        private static void OnFileRenamed(object source, RenamedEventArgs e)
        {
            log.GenerateLog("File: {0} renamed to {1}", e.OldFullPath, e.FullPath + " by " + Environment.UserName);
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath + " by " + Environment.UserName);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Main()
        {
            Watcher obj = new Watcher();
            obj.InitializePath();
            obj.InitializeEvents();
            obj.StartWatcher();
            while (Console.ReadLine() != "q") ;
        }
    }
}