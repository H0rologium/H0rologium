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
        private Button addNewEntryBtn;
        private Button runBackupNowBtn;
        private Label titleLbl;

        #endregion

        public void InitializeComponent()
        {
            titleLbl = new Label();
            backupLocationsPanel = new Panel();
            runBackupNowBtn = new Button();
            addNewEntryBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.Dock = DockStyle.Top;
            titleLbl.Location = new Point(0, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(608, 24);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Backup and Restore Files";
            // 
            // backupLocationsPanel
            // 
            backupLocationsPanel.AutoScroll = true;
            backupLocationsPanel.AutoSize = true;
            backupLocationsPanel.CausesValidation = false;
            backupLocationsPanel.Dock = DockStyle.Fill;
            backupLocationsPanel.Location = new Point(0, 24);
            backupLocationsPanel.Name = "backupLocationsPanel";
            backupLocationsPanel.Size = new Size(608, 378);
            backupLocationsPanel.TabIndex = 1;
            // 
            // runBackupNowBtn
            // 
            runBackupNowBtn.AutoSize = true;
            runBackupNowBtn.Dock = DockStyle.Bottom;
            runBackupNowBtn.Location = new Point(0, 353);
            runBackupNowBtn.Name = "runBackupNowBtn";
            runBackupNowBtn.Size = new Size(608, 25);
            runBackupNowBtn.TabIndex = 3;
            runBackupNowBtn.Text = "Backup Files Now";
            runBackupNowBtn.UseVisualStyleBackColor = true;
            // 
            // addNewEntryBtn
            // 
            addNewEntryBtn.AutoSize = true;
            addNewEntryBtn.Dock = DockStyle.Top;
            addNewEntryBtn.Location = new Point(0, 24);
            addNewEntryBtn.Name = "addNewEntryBtn";
            addNewEntryBtn.Size = new Size(608, 25);
            addNewEntryBtn.TabIndex = 2;
            addNewEntryBtn.Text = "Add Entry";
            addNewEntryBtn.UseVisualStyleBackColor = true;
            addNewEntryBtn.Click += AddNewEntryBtn_Click;
            // 
            // BackupToolWindow
            // 
            ClientSize = new Size(608, 402);
            Controls.Add(addNewEntryBtn);
            Controls.Add(backupLocationsPanel);
            Controls.Add(titleLbl);
            Controls.Add(runBackupNowBtn);
            MinimumSize = new Size(624, 312);
            Name = "BackupToolWindow";
            backupLocationsPanel.ResumeLayout(false);
            backupLocationsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddNewEntryBtn_Click(object? sender, EventArgs e)
        {
            AddNewBackupLocation(new Dictionary<string, string>());
        }

        public void AddNewBackupLocation(Dictionary<string,string> locationToAdd)
        {
            int SEQUENTIAL_PADDING = 4;

            BackupEntryPrefab newLocation = new BackupEntryPrefab();
            newLocation.Dock = DockStyle.Fill;
            //Populate fields. All fields we need to access here are children of the root control.
            ((Label)newLocation.Controls.Find("backupSRClbl", false)[0]).Text = locationToAdd.ContainsKey("BKUPSRC") ? locationToAdd["BKUPSRC"] : "No Source Path Selected";
            ((Label)newLocation.Controls.Find("backupDESTlbl", false)[0]).Text = locationToAdd.ContainsKey("BKUPDEST") ? locationToAdd["BKUPDEST"] : "No Destination Path Selected";
            ((CheckBox)newLocation.Controls.Find("inclSubfolderChkbx", false)[0]).Checked = locationToAdd.ContainsKey("INCLSUBFOLDERS") ? locationToAdd["INCLSUBFOLDERS"].Equals("true") : false;
            ((TextBox)newLocation.Controls.Find("extensionWhiteListTxt", false)[0]).Text = locationToAdd.ContainsKey("EXTWL") ? locationToAdd["EXTWL"] : String.Empty;
            ((TextBox)newLocation.Controls.Find("extensionBlacklistTxt", false)[0]).Text = locationToAdd.ContainsKey("EXTBL") ? locationToAdd["EXTBL"] : String.Empty;

            //Get rid of this magic number before i get rid of you
            newLocation.Height = 120;
            newLocation.Width = backupLocationsPanel.ClientSize.Width;

            newLocation.Dock = DockStyle.None;
            newLocation.AutoSize = false;
            newLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            int nextVertPos = backupLocationsPanel.Controls.Count * (newLocation.Height + SEQUENTIAL_PADDING);
            newLocation.Location = new Point(0, nextVertPos);
            
            backupLocationsPanel.Controls.Add(newLocation);
        }
    }
}
