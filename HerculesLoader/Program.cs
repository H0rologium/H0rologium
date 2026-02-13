using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.Loader;


namespace HerculesLoader
{
    public class Program
    {
        #region Fields

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;


        private static NotifyIcon tray = null;
        private static Icon trayIcon = null;


        

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public Program()
        {
            trayIcon = new Icon($"{AppDomain.CurrentDomain.BaseDirectory}/icon.ico");
        }

        #endregion

        [STAThread]
        static void Main(string[] args)
        {

            if (LoadPlugins())
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE);
                System.Windows.Forms.Application.Run();
            }
            else
            {
                throw new FileLoadException();
            }
            
        }



        private static bool LoadPlugins()
        {
            string pluginDir = $"{AppDomain.CurrentDomain.BaseDirectory}";
            IReadOnlyList<IPlugin> plugins = PluginManager.LoadPlugins();

            //Check if anything valid was loaded
            if (plugins.Count() < 1)
                return false;

            //Populate menu



            return true;
        }
    }
}
