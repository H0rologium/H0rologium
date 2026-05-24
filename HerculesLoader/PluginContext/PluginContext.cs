namespace PluginContext
{
    /// <summary>
    /// The IPluginContext interface MUST be extended in any plugin class, of a plugin that wants to work with HerculesLoader.
    /// </summary>
    public interface IPluginContext
    {
        string Name { get; }
        /// <summary>
        /// Method to set up anything that the plugin might need. If tagging classes to enable logging or setting support, ensure that the parameters passed are assigned somewhere in your plugin.
        /// </summary>
        /// <param name="initialLoggingClassReference">Method to let you store to later reference Hercules Loader's logging methods. This can be passed as NULL if no public classes in the plugin are marked with the 'HerculesLogger' attribute.</param>
        void Initialize(object? initialLoggingClassReference);

        void OnModuleOpen(object? sender, EventArgs e);
    }

    /// <summary>
    /// Declaring a class with this attribute will allow a loaded plugin to store a reference to the Logging class that HerculesLoader provides.
    /// Classes that wish to have an instance stored will need to declare a variable LoggingClass (or a getter/setter with this name) that can store ``object`` types.
    /// Logging methods can be called by invoking the public methods from Logging. You can refer to the Logging class under the base HerculesLoader for more information
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class HerculesLogger : System.Attribute
    {
        public HerculesLogger()
        {

        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class HerculesModifiableSettings : System.Attribute
    {
        public HerculesModifiableSettings()
        {

        }
    }
}
