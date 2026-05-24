using System.Runtime.InteropServices;
using PluginContext;
using HerculesLoader.res;

namespace HerculesLoader
{
    public class Program
    {
        #region Fields

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;


        private static NotifyIcon tray = null;
        private static Icon trayIcon = null;
        private static ContextMenuStrip ctxMenuStrip = null;
        private static readonly Logging _logger = new Logging();

        public Logging Logger { get { return _logger; } }
        

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion


        [STAThread]
        static void Main(string[] args)
        {
            trayIcon = Resource1.Icon;

            if (LoadPlugins(_logger))
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE);
                System.Windows.Forms.Application.Run();
            }
            else
            {
                throw new FileLoadException();
            }
            
        }


        #region WinForms setup methods 
        [STAThread]
        private static bool LoadPlugins(Logging lgr)
        {
            string pluginDir = $"{AppDomain.CurrentDomain.BaseDirectory}";
            //By the time they are added to this collection, plugins are instanced
            IReadOnlyList<IPluginContext> plugins = PluginManager.LoadPlugins(lgr);

            //Check if anything valid was loaded
            if (plugins.Count() < 1)
                return false;

            //Populate menu
            tray = new NotifyIcon()
            {
                Icon = trayIcon,
                Text = "Hercules is Running",
                Visible = true
            };

            ctxMenuStrip = new ContextMenuStrip();
            AddCTXItems(ctxMenuStrip,plugins);
            tray.ContextMenuStrip = ctxMenuStrip;

            return true;
        }

        private static void AddCTXItems(ContextMenuStrip ctxMenu,IReadOnlyList<IPluginContext> plugins)
        {
            
            foreach (IPluginContext p in plugins)
            {
                ctxMenu.Items.Add(p.Name,null,p.OnModuleOpen);
            }
            ctxMenu.Items.Add("Exit", null, OnTBMouseClick);
        }


        private static void OnTBMouseClick(object? _sender, EventArgs _e)
        {
            Console.WriteLine("Closing Hercules");
            tray.Dispose();
            System.Windows.Forms.Application.Exit();
        }
        #endregion
    }
}
