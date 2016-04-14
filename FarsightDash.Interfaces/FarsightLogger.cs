using FarsightDash.Common.Interfaces;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace FarsightDash.Common
{
    public class FarsightLogger : IFarsightLogger
    {
        public static IFarsightLogger DefaultLogger { get; set; }

        private Logger _Logger;

        public FarsightLogger(string logFileName)
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName = "${basedir}/" + logFileName;
            fileTarget.Layout = "${date:format=HH\\:mm\\:ss} ${logger} ${uppercase:${level}} ${message}";

            var rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;

            _Logger = LogManager.GetLogger(logFileName);

        }

        public void LogDebug(string message)
        {
            _Logger.Log(LogLevel.Debug, message);
        }

        public void LogInfo(string message)
        {
            _Logger.Log(LogLevel.Info, message);
        }

        public void LogWarning(string message)
        {
            _Logger.Log(LogLevel.Warn, message);
        }

        public void LogError(string message)
        {
            _Logger.Log(LogLevel.Error, message);
        }

        public void LogFatal(string message)
        {
            _Logger.Log(LogLevel.Fatal, message);
        }
    }
}
