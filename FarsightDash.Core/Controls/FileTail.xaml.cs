using System;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for DirectoryWatcher.xaml
    /// </summary>
    public partial class FileTail : UserControl, ISavableModule, IDashboardView
    {
        private readonly FileSystemWatcher _Watcher;
        private readonly string _FilePath;

        public FileTail(string filePathToTail)
        {
            if (!File.Exists(filePathToTail))
            {
                throw new FileNotFoundException(filePathToTail + " does not exist!");
            }
            InitializeComponent();
            _FilePath = filePathToTail;

            var directory = Path.GetDirectoryName(filePathToTail);
            var fileName = Path.GetFileName(filePathToTail);

            _Watcher = new FileSystemWatcher();
            _Watcher.Path = directory;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            _Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            _Watcher.Filter = fileName;
            _Watcher.EnableRaisingEvents = true;

            _Watcher.Changed += ChangeEventHandler;

            UpdateFileText();
        }

        private void ChangeEventHandler(object sender, FileSystemEventArgs args)
        {
            UpdateFileText();
        }

        private void UpdateFileText()
        {
            Dispatcher.Invoke(() =>
            {
                using (var fileStream = WaitForFile(_FilePath))
                {
                    if (fileStream == null)
                    {
                        FarsightLogger.DefaultLogger.LogError("Failed to read from file, fileStream was null.");
                        return;
                    }
                    var reader = new StreamReader(fileStream);
                    var fileText = reader.ReadToEnd();
                    fileStream.Close();
                    DirectoryChangeLog.Text = fileText;
                    DirectoryChangeLog.ScrollToEnd();
                };
            });
        }

        private FileStream WaitForFile(string fullPath)
        {
            Exception exception = null;
            for (int numTries = 0; numTries < 10; numTries++)
            {
                try
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    fs.ReadByte();
                    fs.Seek(0, SeekOrigin.Begin);

                    return fs;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    FarsightLogger.DefaultLogger.LogInfo(exception.Message);
                    Thread.Sleep(5);
                }
            }

            if (exception != null)
            {
                FarsightLogger.DefaultLogger.LogError("Failed to read from file: " + exception.Message);
            }
            return null;
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(FileTail); }
        }

        public string GetSaveString()
        {
            return _FilePath;
        }

        public UserControl Control { get { return this; } }
    }
}
