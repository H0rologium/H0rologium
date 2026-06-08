using PluginContext;

namespace SettingsModule
{
    public class SettingsModule : IPluginContext
    {
        private readonly string name = "Settings Module";
        private readonly Size windowSize = new Size(960,1012);
        private SettingsModuleLogger logger;
        public string Name { get { return name; } }
        public Size WindowSize { get { return windowSize; } }

        public void Initialize(object? loggingClassRef, string baseDLLPath)
        {
            logger = new SettingsModuleLogger(loggingClassRef);
            logger.LogMessage(0,"Settings has finished initializing");
        }

        public void OnModuleOpen(object? sender, EventArgs e)
        {
            SettingsModuleForm form = new SettingsModuleForm();
            form.InitializeWindow(Name,WindowSize);
        }
    }
}
