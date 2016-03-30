using System;
using System.IO;
using System.Windows.Controls;
using FarsightDash.Common;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for DirectoryWatcher.xaml
    /// </summary>
    public partial class DirectoryWatcher : UserControl
    {
        private readonly FileSystemWatcher _Watcher;
        public DirectoryWatcher(string directoryToWatch)
        {
            if (!Directory.Exists(directoryToWatch))
            {
                throw new FileNotFoundException(directoryToWatch + " does not exist!");
            }
            InitializeComponent();

            _Watcher = new FileSystemWatcher();
            _Watcher.Path = directoryToWatch;

            _Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes
               | NotifyFilters.Size | NotifyFilters.CreationTime | NotifyFilters.Security;

            _Watcher.EnableRaisingEvents = true;

            _Watcher.Changed += ChangeEventHandler;
            _Watcher.Created += CreateEventHandler;
            _Watcher.Deleted += DeleteEventHandler;
            _Watcher.Renamed += RenameEventHandler;
            _Watcher.Error += WatcherErrorEventHandler;

            DirectoryChangeLog.Text += "Watching directory: " + directoryToWatch + Environment.NewLine;
        }

        private void WatcherErrorEventHandler(object sender, ErrorEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Directory Watcher Error Event!");

                DirectoryChangeLog.Text += DateTime.Now + " ERROR: FileWatcher -  " + args.GetException().Message + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void ChangeEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Directory Change Event!");

                DirectoryChangeLog.Text += args.Name + " Changed at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void CreateEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Directory Create Event!");

                DirectoryChangeLog.Text += args.Name + " Created at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void DeleteEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Directory Delete Event!");

                DirectoryChangeLog.Text += args.Name + " Deleted at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void RenameEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Directory Rename Event!");

                DirectoryChangeLog.Text += args.Name + " Renamed at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }
    }
}
