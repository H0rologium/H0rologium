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
        private Label titleLbl;

        #endregion

        public void InitializeComponent()
        {
            titleLbl = new Label();
            titleLbl.Text = "Backup and Restore Files";
            titleLbl.Font = new Font(DEFAULT_FONT, 16);
            this.Controls.Add(titleLbl);
        }
    }
}
