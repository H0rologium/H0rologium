using PluginContext;
using System.IO;

namespace HerculesLoader
{
    public static class PluginManager
    {

        #region fields

        private const string MULTIPLUGINERROR = "Multiple files were found in the same plugin folder using the same prefix. Have we accidentally merged plugins?";

        #endregion

        public static IReadOnlyList<IPluginContext> LoadPlugins(Logging lgr)
        {
            string pluginPath = Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", "plugins");
            List<IPluginContext> plugins = new List<IPluginContext>();

            if (!Directory.Exists(pluginPath)) Directory.CreateDirectory(pluginPath);
            if (!Directory.Exists(pluginPath))
                return plugins;

            foreach (string dir in Directory.GetDirectories(pluginPath))
            {
                //Check for valid plugin, 'valid' in this case meaning the file has a '_plugin' suffix and there's only one file with this suffix
                IEnumerable<string> dirSeach = Directory.EnumerateFiles(dir, "*_plugin.dll");
                if (!dirSeach.Any())
                { continue; }
                if (dirSeach.Count() > 1)
                { throw new FileFormatException(MULTIPLUGINERROR +$" SOURCE: {dir}"); }


                try
                {
                    string dllPath = Path.Combine(dir, dirSeach.First());

                    var ctx = new PluginLoadContext(dllPath);
                    var assem = ctx.LoadFromAssemblyPath(dllPath);

                    Type[] types = assem.GetExportedTypes();
                    //Assign references to base classes where needed.
                    IEnumerable<Type> loggingTypes = types.Where(t => t.IsDefined(typeof(PluginContext.HerculesLogger), inherit: false));
                    
                    plugins.Add(Reflect(types,lgr));

                }
                catch (Exception e) { throw new Exception(e.ToString()); }
            }

            return plugins;
        }

        //Reflection is used to add plugin once loaded
        private static IPluginContext Reflect(Type[] exportedTypes, Logging lgrRef)
        {
            Type? loggingClass = exportedTypes.FirstOrDefault(x => (x.IsClass && x.IsDefined(typeof(PluginContext.HerculesLogger),false)));
            foreach (var t in exportedTypes)
            {
                if (!typeof(IPluginContext).IsAssignableFrom(t) || (t.IsAbstract || t.IsInterface))
                    continue;

                var plugin = (IPluginContext)Activator.CreateInstance(t)!;
                plugin.Initialize((loggingClass != null) ? lgrRef : null);
                return plugin;
            }
            return null;
        }
    }
}
