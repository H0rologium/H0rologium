using PluginContext;

namespace BackupTool
{
    public class BackupToolPlugin : IPluginContext
    {
        #region fields

        private readonly string name = "Backup Tool";
        private readonly Size windowSize = new Size(960, 1012);
        private BackupToolLogger logger;
        private ToolModel _model;

        public string Name { get { return name; } }
        public Size WindowSize { get { return windowSize; } }

        #endregion

        public void Initialize(object? loggingClassRef, string baseDLLPath)
        {
            logger = new BackupToolLogger(loggingClassRef);
            logger.LogMessage(0, $"{Name} has finished initializing");
            _model = new ToolModel(logger,baseDLLPath);
        }

        public void OnModuleOpen(object? sender, EventArgs e)
        {
            BackupToolWindow form = new BackupToolWindow();
            form.InitializeWindow(Name, WindowSize);
            _model.View = form;
            _model.LoadBackupData();
        }
    }
}
