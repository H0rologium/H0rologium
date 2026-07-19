using BackupTool.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupTool
{
    public partial class BackupToolWindow : Form
    {
        public BackupToolWindow()
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
            this.Icon = BackupRES.icon;

            this.ShowDialog();
        }

        #region Forms Fields

        private const string DEFAULT_FONT = "SimSun-ExtG";
        private Panel backupLocationsPanel;
        private Label titleLbl;

        #endregion

        public void InitializeComponent()
        {
            titleLbl = new Label();
            backupLocationsPanel = new Panel();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.Location = new Point(0, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(300, 24);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Backup and Restore Files";
            // 
            // backupLocationsPanel
            // 
            backupLocationsPanel.Location = new Point(26, 26);
            backupLocationsPanel.Name = "backupLocationsPanel";
            backupLocationsPanel.Size = new Size(200, 100);
            backupLocationsPanel.TabIndex = 1;
            // 
            // BackupToolWindow
            // 
            ClientSize = new Size(284, 261);
            Controls.Add(backupLocationsPanel);
            Controls.Add(titleLbl);
            Name = "BackupToolWindow";
            ResumeLayout(false);
        }

        public void AddNewBackupLocation()
        {

        }
    }
}
