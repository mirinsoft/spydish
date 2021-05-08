namespace Privatezilla
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.TvwSettings = new System.Windows.Forms.TreeView();
            this.LblMainMenu = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.CommunityPkg = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlNav = new System.Windows.Forms.Panel();
            this.LblPS = new System.Windows.Forms.LinkLabel();
            this.LblSettings = new System.Windows.Forms.LinkLabel();
            this.LstPS = new System.Windows.Forms.CheckedListBox();
            this.PnlSettings = new System.Windows.Forms.Panel();
            this.assetOpenGitHub = new System.Windows.Forms.PictureBox();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.LvwStatus = new System.Windows.Forms.ListView();
            this.Setting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnSettingsUndo = new System.Windows.Forms.Button();
            this.BtnSettingsDo = new System.Windows.Forms.Button();
            this.BtnSettingsAnalyze = new System.Windows.Forms.Button();
            this.PnlPS = new System.Windows.Forms.Panel();
            this.BtnMenuPS = new System.Windows.Forms.Button();
            this.LblPSHeader = new System.Windows.Forms.Label();
            this.TxtConsolePS = new System.Windows.Forms.TextBox();
            this.TxtPSInfo = new System.Windows.Forms.TextBox();
            this.PSMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PSImport = new System.Windows.Forms.ToolStripMenuItem();
            this.PSSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.PSMarketplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PnlSettingsBottom = new System.Windows.Forms.Panel();
            this.BtnDoPS = new System.Windows.Forms.Button();
            this.ChkCodePS = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            this.PnlNav.SuspendLayout();
            this.PnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetOpenGitHub)).BeginInit();
            this.PnlPS.SuspendLayout();
            this.PSMenu.SuspendLayout();
            this.PnlSettingsBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvwSettings
            // 
            resources.ApplyResources(this.TvwSettings, "TvwSettings");
            this.TvwSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TvwSettings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TvwSettings.CheckBoxes = true;
            this.TvwSettings.LineColor = System.Drawing.Color.DarkOrchid;
            this.TvwSettings.Name = "TvwSettings";
            this.TvwSettings.ShowLines = false;
            this.TvwSettings.ShowNodeToolTips = true;
            this.TvwSettings.ShowPlusMinus = false;
            this.TvwSettings.TabStop = false;
            this.TvwSettings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvwSetting_AfterCheck);
            // 
            // LblMainMenu
            // 
            resources.ApplyResources(this.LblMainMenu, "LblMainMenu");
            this.LblMainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.LblMainMenu.FlatAppearance.BorderSize = 0;
            this.LblMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.LblMainMenu.ForeColor = System.Drawing.Color.Black;
            this.LblMainMenu.Name = "LblMainMenu";
            this.LblMainMenu.UseVisualStyleBackColor = false;
            this.LblMainMenu.Click += new System.EventHandler(this.LblMainMenu_Click);
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help,
            this.CommunityPkg,
            this.CheckRelease,
            this.Info});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // Help
            // 
            resources.ApplyResources(this.Help, "Help");
            this.Help.Name = "Help";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // CommunityPkg
            // 
            resources.ApplyResources(this.CommunityPkg, "CommunityPkg");
            this.CommunityPkg.Name = "CommunityPkg";
            this.CommunityPkg.Click += new System.EventHandler(this.CommunityPkg_Click);
            // 
            // CheckRelease
            // 
            resources.ApplyResources(this.CheckRelease, "CheckRelease");
            this.CheckRelease.Name = "CheckRelease";
            this.CheckRelease.Click += new System.EventHandler(this.CheckRelease_Click);
            // 
            // Info
            // 
            resources.ApplyResources(this.Info, "Info");
            this.Info.Name = "Info";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlNav.Controls.Add(this.LblPS);
            this.PnlNav.Controls.Add(this.LblSettings);
            this.PnlNav.Controls.Add(this.LblMainMenu);
            this.PnlNav.Controls.Add(this.TvwSettings);
            this.PnlNav.Controls.Add(this.LstPS);
            resources.ApplyResources(this.PnlNav, "PnlNav");
            this.PnlNav.Name = "PnlNav";
            // 
            // LblPS
            // 
            this.LblPS.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.LblPS.AutoEllipsis = true;
            resources.ApplyResources(this.LblPS, "LblPS");
            this.LblPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LblPS.LinkColor = System.Drawing.Color.Black;
            this.LblPS.Name = "LblPS";
            this.LblPS.TabStop = true;
            this.LblPS.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.LblPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblPS_LinkClicked);
            // 
            // LblSettings
            // 
            this.LblSettings.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.LblSettings.AutoEllipsis = true;
            resources.ApplyResources(this.LblSettings, "LblSettings");
            this.LblSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LblSettings.LinkColor = System.Drawing.Color.Black;
            this.LblSettings.Name = "LblSettings";
            this.LblSettings.TabStop = true;
            this.LblSettings.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.LblSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblSettings_LinkClicked);
            // 
            // LstPS
            // 
            resources.ApplyResources(this.LstPS, "LstPS");
            this.LstPS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstPS.ForeColor = System.Drawing.Color.Black;
            this.LstPS.FormattingEnabled = true;
            this.LstPS.Name = "LstPS";
            this.LstPS.Sorted = true;
            this.LstPS.ThreeDCheckBoxes = true;
            this.LstPS.SelectedIndexChanged += new System.EventHandler(this.LstPS_SelectedIndexChanged);
            // 
            // PnlSettings
            // 
            resources.ApplyResources(this.PnlSettings, "PnlSettings");
            this.PnlSettings.Controls.Add(this.assetOpenGitHub);
            this.PnlSettings.Controls.Add(this.PBar);
            this.PnlSettings.Controls.Add(this.LvwStatus);
            this.PnlSettings.Controls.Add(this.LblStatus);
            this.PnlSettings.Name = "PnlSettings";
            // 
            // assetOpenGitHub
            // 
            resources.ApplyResources(this.assetOpenGitHub, "assetOpenGitHub");
            this.assetOpenGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assetOpenGitHub.Name = "assetOpenGitHub";
            this.assetOpenGitHub.TabStop = false;
            this.ToolTip.SetToolTip(this.assetOpenGitHub, resources.GetString("assetOpenGitHub.ToolTip"));
            this.assetOpenGitHub.Click += new System.EventHandler(this.assetOpenGitHubPage_Click);
            // 
            // PBar
            // 
            resources.ApplyResources(this.PBar, "PBar");
            this.PBar.Name = "PBar";
            // 
            // LvwStatus
            // 
            resources.ApplyResources(this.LvwStatus, "LvwStatus");
            this.LvwStatus.BackColor = System.Drawing.Color.White;
            this.LvwStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LvwStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Setting,
            this.State});
            this.LvwStatus.FullRowSelect = true;
            this.LvwStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LvwStatus.HideSelection = false;
            this.LvwStatus.Name = "LvwStatus";
            this.LvwStatus.TileSize = new System.Drawing.Size(1, 1);
            this.LvwStatus.UseCompatibleStateImageBehavior = false;
            this.LvwStatus.View = System.Windows.Forms.View.Details;
            this.LvwStatus.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvwStatus_ColumnClick);
            // 
            // Setting
            // 
            resources.ApplyResources(this.Setting, "Setting");
            // 
            // State
            // 
            resources.ApplyResources(this.State, "State");
            // 
            // LblStatus
            // 
            resources.ApplyResources(this.LblStatus, "LblStatus");
            this.LblStatus.AutoEllipsis = true;
            this.LblStatus.BackColor = System.Drawing.Color.White;
            this.LblStatus.Name = "LblStatus";
            // 
            // BtnSettingsUndo
            // 
            resources.ApplyResources(this.BtnSettingsUndo, "BtnSettingsUndo");
            this.BtnSettingsUndo.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsUndo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsUndo.FlatAppearance.BorderSize = 0;
            this.BtnSettingsUndo.Name = "BtnSettingsUndo";
            this.BtnSettingsUndo.UseVisualStyleBackColor = false;
            this.BtnSettingsUndo.Click += new System.EventHandler(this.BtnSettingsUndo_Click);
            // 
            // BtnSettingsDo
            // 
            resources.ApplyResources(this.BtnSettingsDo, "BtnSettingsDo");
            this.BtnSettingsDo.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsDo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsDo.FlatAppearance.BorderSize = 0;
            this.BtnSettingsDo.Name = "BtnSettingsDo";
            this.BtnSettingsDo.UseVisualStyleBackColor = false;
            this.BtnSettingsDo.Click += new System.EventHandler(this.BtnSettingsDo_Click);
            // 
            // BtnSettingsAnalyze
            // 
            resources.ApplyResources(this.BtnSettingsAnalyze, "BtnSettingsAnalyze");
            this.BtnSettingsAnalyze.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsAnalyze.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnSettingsAnalyze.FlatAppearance.BorderSize = 0;
            this.BtnSettingsAnalyze.Name = "BtnSettingsAnalyze";
            this.BtnSettingsAnalyze.UseVisualStyleBackColor = false;
            this.BtnSettingsAnalyze.Click += new System.EventHandler(this.BtnSettingsAnalyze_Click);
            // 
            // PnlPS
            // 
            resources.ApplyResources(this.PnlPS, "PnlPS");
            this.PnlPS.BackColor = System.Drawing.Color.White;
            this.PnlPS.Controls.Add(this.BtnMenuPS);
            this.PnlPS.Controls.Add(this.LblPSHeader);
            this.PnlPS.Controls.Add(this.TxtConsolePS);
            this.PnlPS.Controls.Add(this.TxtPSInfo);
            this.PnlPS.Name = "PnlPS";
            // 
            // BtnMenuPS
            // 
            resources.ApplyResources(this.BtnMenuPS, "BtnMenuPS");
            this.BtnMenuPS.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnMenuPS.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnMenuPS.FlatAppearance.BorderSize = 0;
            this.BtnMenuPS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMenuPS.ForeColor = System.Drawing.Color.Black;
            this.BtnMenuPS.Name = "BtnMenuPS";
            this.BtnMenuPS.UseVisualStyleBackColor = false;
            this.BtnMenuPS.Click += new System.EventHandler(this.BtnMenuPS_Click);
            // 
            // LblPSHeader
            // 
            resources.ApplyResources(this.LblPSHeader, "LblPSHeader");
            this.LblPSHeader.BackColor = System.Drawing.Color.Gainsboro;
            this.LblPSHeader.Name = "LblPSHeader";
            // 
            // TxtConsolePS
            // 
            resources.ApplyResources(this.TxtConsolePS, "TxtConsolePS");
            this.TxtConsolePS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtConsolePS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.TxtConsolePS.BackColor = System.Drawing.Color.PaleTurquoise;
            this.TxtConsolePS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtConsolePS.ForeColor = System.Drawing.Color.Black;
            this.TxtConsolePS.Name = "TxtConsolePS";
            // 
            // TxtPSInfo
            // 
            resources.ApplyResources(this.TxtPSInfo, "TxtPSInfo");
            this.TxtPSInfo.BackColor = System.Drawing.Color.White;
            this.TxtPSInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPSInfo.ForeColor = System.Drawing.Color.Black;
            this.TxtPSInfo.Name = "TxtPSInfo";
            this.TxtPSInfo.ReadOnly = true;
            // 
            // PSMenu
            // 
            this.PSMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.PSMenu, "PSMenu");
            this.PSMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PSImport,
            this.PSSaveAs,
            this.PSMarketplace});
            this.PSMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.PSMenu.Name = "contextHostsMenu";
            this.PSMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // PSImport
            // 
            resources.ApplyResources(this.PSImport, "PSImport");
            this.PSImport.Name = "PSImport";
            this.PSImport.Click += new System.EventHandler(this.PSImport_Click);
            // 
            // PSSaveAs
            // 
            resources.ApplyResources(this.PSSaveAs, "PSSaveAs");
            this.PSSaveAs.Name = "PSSaveAs";
            this.PSSaveAs.Click += new System.EventHandler(this.PSSaveAs_Click);
            // 
            // PSMarketplace
            // 
            this.PSMarketplace.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.PSMarketplace, "PSMarketplace");
            this.PSMarketplace.ForeColor = System.Drawing.Color.Black;
            this.PSMarketplace.Name = "PSMarketplace";
            this.PSMarketplace.Click += new System.EventHandler(this.PSMarketplace_Click);
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 0;
            this.ToolTip.AutoPopDelay = 15000;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.UseAnimation = false;
            this.ToolTip.UseFading = false;
            // 
            // PnlSettingsBottom
            // 
            this.PnlSettingsBottom.Controls.Add(this.BtnSettingsUndo);
            this.PnlSettingsBottom.Controls.Add(this.BtnSettingsDo);
            this.PnlSettingsBottom.Controls.Add(this.BtnDoPS);
            this.PnlSettingsBottom.Controls.Add(this.BtnSettingsAnalyze);
            this.PnlSettingsBottom.Controls.Add(this.ChkCodePS);
            resources.ApplyResources(this.PnlSettingsBottom, "PnlSettingsBottom");
            this.PnlSettingsBottom.Name = "PnlSettingsBottom";
            // 
            // BtnDoPS
            // 
            resources.ApplyResources(this.BtnDoPS, "BtnDoPS");
            this.BtnDoPS.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnDoPS.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BtnDoPS.FlatAppearance.BorderSize = 0;
            this.BtnDoPS.Name = "BtnDoPS";
            this.BtnDoPS.UseVisualStyleBackColor = false;
            this.BtnDoPS.Click += new System.EventHandler(this.BtnDoPS_Click);
            // 
            // ChkCodePS
            // 
            resources.ApplyResources(this.ChkCodePS, "ChkCodePS");
            this.ChkCodePS.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkCodePS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ChkCodePS.FlatAppearance.BorderSize = 0;
            this.ChkCodePS.ForeColor = System.Drawing.Color.Black;
            this.ChkCodePS.Name = "ChkCodePS";
            this.ChkCodePS.UseVisualStyleBackColor = false;
            this.ChkCodePS.CheckedChanged += new System.EventHandler(this.ChkCodePS_CheckedChanged);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlSettingsBottom);
            this.Controls.Add(this.PnlNav);
            this.Controls.Add(this.PnlSettings);
            this.Controls.Add(this.PnlPS);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.MainMenu.ResumeLayout(false);
            this.PnlNav.ResumeLayout(false);
            this.PnlNav.PerformLayout();
            this.PnlSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assetOpenGitHub)).EndInit();
            this.PnlPS.ResumeLayout(false);
            this.PnlPS.PerformLayout();
            this.PSMenu.ResumeLayout(false);
            this.PnlSettingsBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView TvwSettings;
        private System.Windows.Forms.Button LblMainMenu;
        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem CheckRelease;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.Panel PnlNav;
        private System.Windows.Forms.LinkLabel LblSettings;
        private System.Windows.Forms.LinkLabel LblPS;
        private System.Windows.Forms.CheckedListBox LstPS;
        private System.Windows.Forms.Panel PnlSettings;
        private System.Windows.Forms.ListView LvwStatus;
        private System.Windows.Forms.ColumnHeader Setting;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.Button BtnSettingsUndo;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnSettingsDo;
        private System.Windows.Forms.Button BtnSettingsAnalyze;
        private System.Windows.Forms.Panel PnlPS;
        private System.Windows.Forms.TextBox TxtPSInfo;
        private System.Windows.Forms.TextBox TxtConsolePS;
        private System.Windows.Forms.ContextMenuStrip PSMenu;
        private System.Windows.Forms.ToolStripMenuItem PSImport;
        private System.Windows.Forms.ToolStripMenuItem PSSaveAs;
        private System.Windows.Forms.ToolStripMenuItem PSMarketplace;
        private System.Windows.Forms.ToolStripMenuItem CommunityPkg;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button BtnMenuPS;
        private System.Windows.Forms.Label LblPSHeader;
        private System.Windows.Forms.PictureBox assetOpenGitHub;
        private System.Windows.Forms.Panel PnlSettingsBottom;
        private System.Windows.Forms.Button BtnDoPS;
        private System.Windows.Forms.CheckBox ChkCodePS;
    }
}

