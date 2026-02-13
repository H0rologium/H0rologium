using System.Reflection;
using System.Runtime.Loader;


namespace HerculesLoader
{
    public class PluginLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;

        public PluginLoadContext(string pluginPath): base(isCollectible: false) // set true later if unloading gets added
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string path = _resolver.ResolveAssemblyToPath(assemblyName);

            if (path != null)
                return LoadFromAssemblyPath(path);

            return null;
        }
    }
}
