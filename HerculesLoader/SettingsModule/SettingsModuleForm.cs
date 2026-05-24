using SettingsModule.res;
using System.Windows.Forms;
namespace SettingsModule
{
    public class SettingsModuleForm : Form
    {

        public SettingsModuleForm()
        {
            InitializeComponent();
        }
        
        public void InitializeWindow(string name, Size size)
        {
            this.Text = name;
            this.Capture = false;
            this.ShowInTaskbar = true;
            this.Size = size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SettingsRes.icon;

            this.ShowDialog();
        }


        #region Forms Fields

        private const string DEFAULT_FONT = "SimSun-ExtG";

        //CS8618 wah wah wah

        private Label titleLbl;

        #endregion

        public void InitializeComponent()
        {
            titleLbl = new Label();
            titleLbl.Text = "Settings";
            titleLbl.Font = new Font(DEFAULT_FONT, 16);
            this.Controls.Add(titleLbl);
        }
    }
}
