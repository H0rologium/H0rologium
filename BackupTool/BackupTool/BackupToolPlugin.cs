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
        private ToolController _controller;

        public string Name { get { return name; } }
        public Size WindowSize { get { return windowSize; } }

        #endregion

        public void Initialize(object? loggingClassRef, string baseDLLPath)
        {
            logger = new BackupToolLogger(loggingClassRef);
            logger.LogMessage(0, $"{Name} has finished initializing");
            _model = new ToolModel(logger,baseDLLPath);
            _controller = new ToolController(logger);
        }

        public void OnModuleOpen(object? sender, EventArgs e)
        {
            BackupToolWindow form = new BackupToolWindow();
            form.InitializeWindow(Name, WindowSize);
            //Set up MVC relationships.
            _controller.View = form;
            _controller.Model = _model;
            _model.Controller = _controller;
            //
            _model.LoadBackupData();
        }
    }
}
