using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FarsightDash.Controls
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
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            _Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            _Watcher.Filter = "*.txt";
            _Watcher.EnableRaisingEvents = true;

            _Watcher.Changed += ChangeEventHandler;
            _Watcher.Created += CreateEventHandler;
            _Watcher.Deleted += DeleteEventHandler;
            _Watcher.Renamed += RenameEventHandler;

            DirectoryChangeLog.Text += "Watching directory: " + directoryToWatch + Environment.NewLine;
        }

        private void ChangeEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                DirectoryChangeLog.Text += args.Name + " Changed at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void CreateEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                DirectoryChangeLog.Text += args.Name + " Created at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void DeleteEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                DirectoryChangeLog.Text += args.Name + " Deleted at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }

        private void RenameEventHandler(object sender, FileSystemEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                DirectoryChangeLog.Text += args.Name + " Renamed at: " + DateTime.Now + Environment.NewLine;
                DirectoryChangeLog.ScrollToEnd();
            });
        }
    }
}
