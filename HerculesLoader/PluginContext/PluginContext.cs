namespace PluginContext
{
    public interface PluginContext
    {
        string Name { get; }

        void Initialize();
    }
}
