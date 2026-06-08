using PluginContext;

namespace BackupTool
{
    public class BackupToolPlugin : IPluginContext
    {
        #region fields

        private readonly string name = "Backup Tool";
        private readonly Size windowSize = new Size(960, 1012);
        private BackupToolLogger logger;

        public string Name { get { return name; } }
        public Size WindowSize { get { return windowSize; } }

        #endregion

        public void Initialize(object? loggingClassRef)
        {
            logger = new BackupToolLogger(loggingClassRef);
            logger.LogMessage(0, $"{Name} has finished initializing");
        }

        public void OnModuleOpen(object? sender, EventArgs e)
        {
            BackupToolWindow form = new BackupToolWindow();
            form.InitializeWindow(Name, WindowSize);
        }
    }
}
