using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;

namespace Intrusion_detection_system
{
    /// <summary>
    /// Interaction logic for IdsReports.xaml
    /// </summary>
    public partial class IdsReports : Page
    {
        private string path = string.Empty;
        private Backend.Watcher watcher = new Backend.Watcher();
        private Backend.LogGenerater log = new Backend.LogGenerater();
        
        public IdsReports(string path)
        {
            this.path = path;
            watcher.Watch.Path = this.path;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.watcher.StartWatcher();
            InitializeEvents();
        }

        /*
         *This method initializes all the events.
         * @param:Nothing.
         * @returns:Nothing.
         */
        public void InitializeEvents()
        {
            // Adding event handlers.
            watcher.Watch.Changed += new FileSystemEventHandler(OnFileChanged);
            watcher.Watch.Created += new FileSystemEventHandler(OnFileChanged);
            watcher.Watch.Deleted += new FileSystemEventHandler(OnFileChanged);
            watcher.Watch.Renamed += new RenamedEventHandler(OnFileRenamed);
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. 
            watcher.Watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        }

        // Define the event handlers.
        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            string action;
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                action = "File created: " + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now;
                this.Dispatcher.Invoke(() => {
                    Report_Block.Text += action;
                });
                log.GenerateLog(action);
            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                action = "File changed: " + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now;
                this.Dispatcher.Invoke(() => {
                    Report_Block.Text += action;
                });
                log.GenerateLog(action);
            }
            else
            {
                action = "File: " + e.FullPath + " " + e.ChangeType + " by " + Environment.UserName + " on " + DateTime.Now;
                this.Dispatcher.Invoke(() => {
                    Report_Block.Text += action;
                });
                log.GenerateLog(action);
            }
        }

        private void OnFileRenamed(object source, RenamedEventArgs e)
        {
            string action;
            action = "File:" + e.OldFullPath + " renamed to" + e.FullPath + " by " + Environment.UserName + " on " + DateTime.Now;
            this.Dispatcher.Invoke(() => {
                Report_Block.Text += action;
            });
            log.GenerateLog(action);
        }

        private void Stop_Clicked(object source, RoutedEventArgs e)
        {
            this.watcher.StopWatcher();
            MessageBox.Show("Watcher Stopped successfully!");
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

    }
}
