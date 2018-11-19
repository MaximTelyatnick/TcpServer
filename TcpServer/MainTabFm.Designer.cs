namespace TVM_WMS.SERVER
{
    partial class MainTabFm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabFm));
            this.settingsMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.testItem = new DevExpress.XtraNavBar.NavBarItem();
            this.userItem = new DevExpress.XtraNavBar.NavBarItem();
            this.settingItem = new DevExpress.XtraNavBar.NavBarItem();
            this.settingsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.logMessageEdit = new DevExpress.XtraEditors.MemoEdit();
            this.menuNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.settingsItemNavBar = new DevExpress.XtraNavBar.NavBarGroup();
            this.testsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.settItem = new DevExpress.XtraNavBar.NavBarItem();
            this.settingImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.serverLiveOrDieTimer = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logMessageEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuNavBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsMenu
            // 
            this.settingsMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsMenu.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.settingsMenu.Appearance.Options.UseFont = true;
            this.settingsMenu.Caption = "Настройки";
            this.settingsMenu.Expanded = true;
            this.settingsMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.settingsMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.testItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.userItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.settingItem)});
            this.settingsMenu.Name = "settingsMenu";
            // 
            // testItem
            // 
            this.testItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testItem.Appearance.Options.UseFont = true;
            this.testItem.Caption = "Тестирвоание";
            this.testItem.Name = "testItem";
            // 
            // userItem
            // 
            this.userItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userItem.Appearance.Options.UseFont = true;
            this.userItem.Caption = "Группы пользователей";
            this.userItem.Name = "userItem";
            // 
            // settingItem
            // 
            this.settingItem.Caption = "Настройки";
            this.settingItem.Name = "settingItem";
            // 
            // settingsItem
            // 
            this.settingsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsItem.Appearance.Options.UseFont = true;
            this.settingsItem.Caption = "Настрйоки системы";
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("settingsItem.SmallImage")));
            // 
            // documentManager
            // 
            this.documentManager.MdiParent = this;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView,
            this.noDocumentsView1});
            // 
            // tabbedView
            // 
            this.tabbedView.RootContainer.Element = null;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.logMessageEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 648);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1327, 137);
            this.panelControl1.TabIndex = 0;
            // 
            // logMessageEdit
            // 
            this.logMessageEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logMessageEdit.Location = new System.Drawing.Point(2, 2);
            this.logMessageEdit.Name = "logMessageEdit";
            this.logMessageEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.logMessageEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.logMessageEdit.Properties.Appearance.Options.UseBackColor = true;
            this.logMessageEdit.Properties.Appearance.Options.UseForeColor = true;
            this.logMessageEdit.Size = new System.Drawing.Size(1323, 133);
            this.logMessageEdit.TabIndex = 1;
            // 
            // menuNavBar
            // 
            this.menuNavBar.ActiveGroup = this.settingsItemNavBar;
            this.menuNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuNavBar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.settingsItemNavBar});
            this.menuNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.testsItem,
            this.settItem});
            this.menuNavBar.Location = new System.Drawing.Point(0, 0);
            this.menuNavBar.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.menuNavBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.menuNavBar.Name = "menuNavBar";
            this.menuNavBar.OptionsNavPane.ExpandedWidth = 402;
            this.menuNavBar.Size = new System.Drawing.Size(402, 648);
            this.menuNavBar.TabIndex = 5;
            this.menuNavBar.Text = "navBarControl1";
            this.menuNavBar.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
            this.menuNavBar.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.menuNavBar_LinkClicked);
            // 
            // settingsItemNavBar
            // 
            this.settingsItemNavBar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsItemNavBar.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.settingsItemNavBar.Appearance.Options.UseFont = true;
            this.settingsItemNavBar.Caption = "Настройки";
            this.settingsItemNavBar.Expanded = true;
            this.settingsItemNavBar.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.settingsItemNavBar.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.testsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.settItem)});
            this.settingsItemNavBar.Name = "settingsItemNavBar";
            // 
            // testsItem
            // 
            this.testsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testsItem.Appearance.Options.UseFont = true;
            this.testsItem.Caption = "Тестирвоание";
            this.testsItem.LargeImage = ((System.Drawing.Image)(resources.GetObject("testsItem.LargeImage")));
            this.testsItem.Name = "testsItem";
            this.testsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("testsItem.SmallImage")));
            // 
            // settItem
            // 
            this.settItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settItem.Appearance.Options.UseFont = true;
            this.settItem.Caption = "Настройки";
            this.settItem.LargeImage = ((System.Drawing.Image)(resources.GetObject("settItem.LargeImage")));
            this.settItem.Name = "settItem";
            this.settItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("settItem.SmallImage")));
            // 
            // settingImageCollection
            // 
            this.settingImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("settingImageCollection.ImageStream")));
            this.settingImageCollection.Images.SetKeyName(0, "run.ico");
            this.settingImageCollection.Images.SetKeyName(1, "stop.ico");
            // 
            // serverLiveOrDieTimer
            // 
            this.serverLiveOrDieTimer.Tick += new System.EventHandler(this.serverLiveOrDieTimer_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Нажмите, чтобы отобразить панель управления сервером.";
            this.trayIcon.BalloonTipTitle = "Подсказка";
            this.trayIcon.Text = "Панель управления сервером склада";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // MainTabFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 785);
            this.Controls.Add(this.menuNavBar);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.MaximizeBox = false;
            this.Name = "MainTabFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainTabFm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logMessageEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuNavBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarGroup settingsMenu;
        private DevExpress.XtraNavBar.NavBarItem testItem;
        private DevExpress.XtraNavBar.NavBarItem userItem;
        private DevExpress.XtraNavBar.NavBarItem settingsItem;
        private DevExpress.XtraNavBar.NavBarItem settingItem;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView noDocumentsView1;
        private DevExpress.XtraNavBar.NavBarControl menuNavBar;
        private DevExpress.XtraNavBar.NavBarGroup settingsItemNavBar;
        private DevExpress.XtraNavBar.NavBarItem testsItem;
        private DevExpress.XtraNavBar.NavBarItem settItem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit logMessageEdit;
        private DevExpress.Utils.ImageCollection settingImageCollection;
        private System.Windows.Forms.Timer serverLiveOrDieTimer;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;

    }
}