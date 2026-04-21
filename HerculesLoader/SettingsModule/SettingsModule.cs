using PluginContext;

namespace SettingsModule
{
    public class SettingsModule : IPluginContext
    {
        private readonly string name = "Settings Module";
        public string Name { get { return name; } }

        public void Initialize()
        {
            Console.WriteLine("Settings loaded");
        }

        public void OnModuleOpen(object? sender, EventArgs e)
        {
            Console.WriteLine("Settings opened");
        }
    }
}
