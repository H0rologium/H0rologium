using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTest
{
    //https://stackoverflow.com/questions/2905783/how-to-effectively-draw-on-desktop-in-c
    //https://stackoverflow.com/questions/683330/how-to-make-a-window-always-stay-on-top-in-net
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
