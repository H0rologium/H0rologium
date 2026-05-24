using PluginContext;

namespace SettingsModule
{
    [HerculesLogger]
    public class SettingsModuleLogger
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

        public SettingsModuleLogger(object? logClass)
        {
            loggingClass = (logClass == null ? null : logClass);
            enableLogging = (logClass != null);
        }

        public void LogMessage(LogLevel level ,string message)
        {
            if (!enableLogging) return;
            //CS8602 shouldn't be an issue here as long as enableLogging is actually getting set to the right level. Is it possibly bad practice? maybe. Is it a wordy one-liner that impresses codewars kids? yes :)
            Console.WriteLine(LoggingClass.GetType().FullName);
            Console.WriteLine(LoggingClass.GetType().AssemblyQualifiedName);
            var method = LoggingClass.GetType().GetMethod((level == LogLevel.ERROR ? "LogError" : (level == LogLevel.WARNING ? "LogWarning" : "LogInfo")), new[] { typeof(string) });
            method.Invoke(LoggingClass, new object[] { message });
            return;
        }
    }
}
