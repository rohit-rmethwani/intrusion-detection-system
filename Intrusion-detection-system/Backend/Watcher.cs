using System;
using System.IO;

namespace Intrusion_detection_system.Backend
{
    class Watcher
    {
        private FileSystemWatcher watch;
        private LogGenerater log;
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        public LogGenerater Log
        {
            get
            {
                return log;
            }
        }
        public FileSystemWatcher Watch
        {
            get
            {
                return watch;
            }
        }
        public Watcher()
        {
            watch = new FileSystemWatcher();
            log = new LogGenerater();
            //InitializePath();
            //InitializeEvents();
        }
        /*
         *This method starts the FileWatcher. 
         * @param: Nothing.
         * @returns: Nothing.
         */
        public void StartWatcher()
        {
            watch.EnableRaisingEvents = true;
        }

        /*
         * This method stops the FileWatcher.
         * @param:Nothing.
         * @returns:Nothing.
         */
        public void StopWatcher()
        {
            watch.EnableRaisingEvents = false;
        }

        /*
         *This method initializes all the events.
         * @param:Nothing.
         * @returns:Nothing.
         */
        /*public void InitializeEvents()
        {
            // Adding event handlers.
            watcher.Changed += new FileSystemEventHandler(OnFileChanged);
            watcher.Created += new FileSystemEventHandler(OnFileChanged);
            watcher.Deleted += new FileSystemEventHandler(OnFileChanged);
            watcher.Renamed += new RenamedEventHandler(OnFileRenamed);
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        }
        */
        /*
         * This method initializes the Path for the directory/file to be watched.
         * @param:Nothing.
         * @returns:Nothing.
         */
         /*
        public void InitializePath()
        {
            Console.WriteLine("Enter the path:");
            Path = Console.ReadLine();
            watcher.Path = Path;
        }
        */
        /*
        // Define the event handlers.
        private void OnFileChanged(object source, FileSystemEventArgs e)
        {

            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                log.GenerateLog("File created: " + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now);
            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                log.GenerateLog("File changed: " + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now);
            }
            else
            {
                log.GenerateLog("File: " + e.FullPath + " " + e.ChangeType + " by " + Environment.UserName + " on " + DateTime.Now);
            }
        }
        */
        /*
        private void OnFileRenamed(object source, RenamedEventArgs e)
        {
            log.GenerateLog("File:" + e.OldFullPath + " renamed to" + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now);
        }
        */
    }
}
