namespace BackupTool
{
    partial class BackupEntryPrefab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backupSRClbl = new Label();
            selectSrcPathBtn = new Button();
            srcPathTooltip = new ToolTip(components);
            backupDESTlbl = new Label();
            selectDestPathBtn = new Button();
            inclSubfolderChkbx = new CheckBox();
            extensionWhiteListTxt = new TextBox();
            extensionBlacklistTxt = new TextBox();
            extensionWhitelistLbl = new Label();
            extensionBlacklistLbl = new Label();
            removeEntryBtn = new Button();
            SuspendLayout();
            // 
            // backupSRClbl
            // 
            backupSRClbl.AutoSize = true;
            backupSRClbl.BackColor = SystemColors.ScrollBar;
            backupSRClbl.Location = new Point(4, 7);
            backupSRClbl.Name = "backupSRClbl";
            backupSRClbl.Size = new Size(31, 15);
            backupSRClbl.TabIndex = 0;
            backupSRClbl.Text = "Path";
            // 
            // selectSrcPathBtn
            // 
            selectSrcPathBtn.Location = new Point(444, 3);
            selectSrcPathBtn.Name = "selectSrcPathBtn";
            selectSrcPathBtn.Size = new Size(114, 23);
            selectSrcPathBtn.TabIndex = 1;
            selectSrcPathBtn.Text = "Select Source";
            selectSrcPathBtn.UseVisualStyleBackColor = true;
            // 
            // srcPathTooltip
            // 
            srcPathTooltip.ToolTipTitle = "Select the path to back up data from";
            // 
            // backupDESTlbl
            // 
            backupDESTlbl.AutoSize = true;
            backupDESTlbl.BackColor = SystemColors.ScrollBar;
            backupDESTlbl.Location = new Point(4, 35);
            backupDESTlbl.Name = "backupDESTlbl";
            backupDESTlbl.Size = new Size(31, 15);
            backupDESTlbl.TabIndex = 0;
            backupDESTlbl.Text = "Path";
            // 
            // selectDestPathBtn
            // 
            selectDestPathBtn.Location = new Point(443, 31);
            selectDestPathBtn.Name = "selectDestPathBtn";
            selectDestPathBtn.Size = new Size(115, 23);
            selectDestPathBtn.TabIndex = 2;
            selectDestPathBtn.Text = "Select Destination";
            selectDestPathBtn.UseVisualStyleBackColor = true;
            // 
            // inclSubfolderChkbx
            // 
            inclSubfolderChkbx.AutoSize = true;
            inclSubfolderChkbx.BackColor = SystemColors.ScrollBar;
            inclSubfolderChkbx.Cursor = Cursors.Hand;
            inclSubfolderChkbx.Location = new Point(4, 63);
            inclSubfolderChkbx.Name = "inclSubfolderChkbx";
            inclSubfolderChkbx.Size = new Size(124, 19);
            inclSubfolderChkbx.TabIndex = 3;
            inclSubfolderChkbx.Text = "Include Subfolders";
            inclSubfolderChkbx.UseVisualStyleBackColor = false;
            // 
            // extensionWhiteListTxt
            // 
            extensionWhiteListTxt.Location = new Point(258, 61);
            extensionWhiteListTxt.Name = "extensionWhiteListTxt";
            extensionWhiteListTxt.Size = new Size(300, 23);
            extensionWhiteListTxt.TabIndex = 4;
            extensionWhiteListTxt.Text = "Lorem Ipsum Lorem Ipsum Lorem Ipsum";
            // 
            // extensionBlacklistTxt
            // 
            extensionBlacklistTxt.Location = new Point(258, 90);
            extensionBlacklistTxt.Name = "extensionBlacklistTxt";
            extensionBlacklistTxt.Size = new Size(300, 23);
            extensionBlacklistTxt.TabIndex = 5;
            extensionBlacklistTxt.Text = "Lorem Ipsum Lorem Ipsum Lorem Ipsum";
            // 
            // extensionWhitelistLbl
            // 
            extensionWhitelistLbl.AutoSize = true;
            extensionWhitelistLbl.Location = new Point(145, 65);
            extensionWhitelistLbl.Name = "extensionWhitelistLbl";
            extensionWhitelistLbl.Size = new Size(107, 15);
            extensionWhitelistLbl.TabIndex = 6;
            extensionWhitelistLbl.Text = "Extension Whitelist";
            // 
            // extensionBlacklistLbl
            // 
            extensionBlacklistLbl.AutoSize = true;
            extensionBlacklistLbl.Location = new Point(145, 93);
            extensionBlacklistLbl.Name = "extensionBlacklistLbl";
            extensionBlacklistLbl.Size = new Size(104, 15);
            extensionBlacklistLbl.TabIndex = 7;
            extensionBlacklistLbl.Text = "Extension Blacklist";
            // 
            // removeEntryBtn
            // 
            removeEntryBtn.Location = new Point(4, 90);
            removeEntryBtn.Name = "removeEntryBtn";
            removeEntryBtn.Size = new Size(124, 23);
            removeEntryBtn.TabIndex = 8;
            removeEntryBtn.Text = "Remove Entry";
            removeEntryBtn.UseVisualStyleBackColor = true;
            // 
            // BackupEntryPrefab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(removeEntryBtn);
            Controls.Add(extensionBlacklistLbl);
            Controls.Add(extensionWhitelistLbl);
            Controls.Add(extensionBlacklistTxt);
            Controls.Add(extensionWhiteListTxt);
            Controls.Add(inclSubfolderChkbx);
            Controls.Add(selectDestPathBtn);
            Controls.Add(backupDESTlbl);
            Controls.Add(selectSrcPathBtn);
            Controls.Add(backupSRClbl);
            Margin = new Padding(0, 0, 0, 0);
            MaximumSize = new Size(2000, 120);
            Name = "BackupEntryPrefab";
            Size = new Size(567, 119);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backupSRClbl;
        private Button selectSrcPathBtn;
        private ToolTip srcPathTooltip;
        private Label backupDESTlbl;
        private Button selectDestPathBtn;
        private CheckBox inclSubfolderChkbx;
        private TextBox extensionWhiteListTxt;
        private TextBox extensionBlacklistTxt;
        private Label extensionWhitelistLbl;
        private Label extensionBlacklistLbl;
        private Button removeEntryBtn;
    }
}
