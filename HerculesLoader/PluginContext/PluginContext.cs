namespace PluginContext
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPluginContext
    {
        string Name { get; }
        void Initialize();

        void OnModuleOpen(object? sender, EventArgs e);
    }
}
