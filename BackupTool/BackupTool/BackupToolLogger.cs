using PluginContext;
namespace BackupTool
{
    [HerculesLogger]
    public class BackupToolLogger
    {
        private readonly object? loggingClass;
        private readonly bool enableLogging;
        public enum LogLevel
        {
            INFO,
            WARNING,
            ERROR
        }

        public object LoggingClass { get { return loggingClass; } }

        public BackupToolLogger(object? logClass)
        {
            loggingClass = (logClass == null ? null : logClass);
            enableLogging = (logClass != null);
        }

        public void LogMessage(LogLevel level, string message)
        {
            if (!enableLogging) return;
            var method = LoggingClass.GetType().GetMethod((level == LogLevel.ERROR ? "LogError" : (level == LogLevel.WARNING ? "LogWarning" : "LogInfo")), new[] { typeof(string) });
            method.Invoke(LoggingClass, new object[] { message });
            return;
        }
    }
}
