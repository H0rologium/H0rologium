namespace HerculesLoader
{
    public static class PluginManager
    {

        #region fields

        private const string MULTIPLUGINERROR = "Multiple files were found in the same plugin folder using the same prefix. Have we accidentally merged plugins?";

        #endregion

        public static IReadOnlyList<IPlugin> LoadPlugins()
        {
            List<IPlugin> plugins = new List<IPlugin>();
            string pRoot = Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", "plugins");
            if (!Directory.Exists(pRoot))
                return plugins;

            foreach (var dir in Directory.GetDirectories(pRoot))
            {
                //Check for valid plugin, 'valid' in this case meaning the file has a '_plugin' suffix and there's only one file with this suffix
                IEnumerable<string> dirSeach = Directory.EnumerateFiles(dir, "*_plugin");
                if (!dirSeach.Any())
                { continue; }
                if (dirSeach.Count() > 1)
                { throw new FileFormatException(MULTIPLUGINERROR +$" SOURCE: {dir}"); }


                try
                {
                    string dllPath = Path.Combine(dir, dirSeach.First());

                    var ctx = new PluginLoadContext(dllPath);
                    var assem = ctx.LoadFromAssemblyPath(dllPath);

                    plugins.Add(Reflect(assem.GetExportedTypes()));

                    return plugins;
                }
                catch (Exception e) { throw new Exception(e.ToString()); }
            }

            return plugins;
        }

        //Reflection is used to add plugin once loaded
        private static IPlugin Reflect(Type[] exportedTypes)
        {
            foreach (var t in exportedTypes)
            {
                if (!typeof(IPlugin).IsAssignableFrom(t) || (t.IsAbstract || t.IsInterface))
                    continue;

                var plugin = (IPlugin)Activator.CreateInstance(t)!;
                plugin.Initialize();
                return plugin;
            }
            return null;
        }
    }
}
