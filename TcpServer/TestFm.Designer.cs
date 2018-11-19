namespace TVM_WMS.SERVER
{
    partial class TestFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestFm));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.deviceTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeIconImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.testSplashManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            this.plcVarGrid = new DevExpress.XtraGrid.GridControl();
            this.plcVarGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.propertyCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.valueCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.curTimeCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.connectPlcBtnItem = new DevExpress.XtraBars.BarButtonItem();
            this.disconnectPlcBtnItem = new DevExpress.XtraBars.BarButtonItem();
            this.listenDbBtnItem = new DevExpress.XtraBars.BarButtonItem();
            this.listemStopDbBtnItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeIconImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcVarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcVarGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Light Gray";
            // 
            // closeBtn
            // 
            this.closeBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(813, 537);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(87, 28);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupControl1.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Navy;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.deviceTree);
            this.groupControl1.Location = new System.Drawing.Point(12, 44);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(328, 485);
            this.groupControl1.TabIndex = 44;
            this.groupControl1.Text = "Дерево оборудования";
            // 
            // deviceTree
            // 
            this.deviceTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gray;
            this.deviceTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.deviceTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.deviceTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.deviceTree.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gray;
            this.deviceTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.deviceTree.Appearance.FocusedRow.Options.UseBackColor = true;
            this.deviceTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.deviceTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3});
            this.deviceTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.deviceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceTree.Location = new System.Drawing.Point(2, 26);
            this.deviceTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deviceTree.Name = "deviceTree";
            this.deviceTree.OptionsBehavior.PopulateServiceColumns = true;
            this.deviceTree.Size = new System.Drawing.Size(324, 457);
            this.deviceTree.StateImageList = this.treeIconImageCollection;
            this.deviceTree.TabIndex = 4;
            this.deviceTree.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.deviceTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.deviceTree_FocusedNodeChanged);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeListColumn3.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "Наименование";
            this.treeListColumn3.FieldName = "Наименование";
            this.treeListColumn3.MinWidth = 52;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 316;
            // 
            // treeIconImageCollection
            // 
            this.treeIconImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("treeIconImageCollection.ImageStream")));
            this.treeIconImageCollection.InsertGalleryImage("play_16x16.png", "images/arrows/play_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/play_16x16.png"), 0);
            this.treeIconImageCollection.Images.SetKeyName(0, "play_16x16.png");
            this.treeIconImageCollection.InsertGalleryImage("close_16x16.png", "images/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png"), 1);
            this.treeIconImageCollection.Images.SetKeyName(1, "close_16x16.png");
            this.treeIconImageCollection.InsertGalleryImage("show_16x16.png", "images/actions/show_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/show_16x16.png"), 2);
            this.treeIconImageCollection.Images.SetKeyName(2, "show_16x16.png");
            this.treeIconImageCollection.InsertGalleryImage("hide_16x16.png", "images/actions/hide_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/hide_16x16.png"), 3);
            this.treeIconImageCollection.Images.SetKeyName(3, "hide_16x16.png");
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Hovered.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Hovered.Options.UseBackColor = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(83, 257);
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // testSplashManager
            // 
            this.testSplashManager.ClosingDelay = 500;
            // 
            // plcVarGrid
            // 
            this.plcVarGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.plcVarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plcVarGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plcVarGrid.Location = new System.Drawing.Point(2, 26);
            this.plcVarGrid.MainView = this.plcVarGridView;
            this.plcVarGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plcVarGrid.Name = "plcVarGrid";
            this.plcVarGrid.Size = new System.Drawing.Size(550, 457);
            this.plcVarGrid.TabIndex = 19;
            this.plcVarGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.plcVarGridView,
            this.gridView1});
            // 
            // plcVarGridView
            // 
            this.plcVarGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.propertyCol,
            this.valueCol,
            this.curTimeCol});
            this.plcVarGridView.GridControl = this.plcVarGrid;
            this.plcVarGridView.Name = "plcVarGridView";
            this.plcVarGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.plcVarGridView.OptionsView.ShowGroupPanel = false;
            // 
            // propertyCol
            // 
            this.propertyCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertyCol.AppearanceHeader.Options.UseFont = true;
            this.propertyCol.AppearanceHeader.Options.UseTextOptions = true;
            this.propertyCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.propertyCol.Caption = "Переменные памяти";
            this.propertyCol.FieldName = "Name";
            this.propertyCol.Name = "propertyCol";
            this.propertyCol.OptionsColumn.AllowEdit = false;
            this.propertyCol.Visible = true;
            this.propertyCol.VisibleIndex = 0;
            this.propertyCol.Width = 131;
            // 
            // valueCol
            // 
            this.valueCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueCol.AppearanceHeader.Options.UseFont = true;
            this.valueCol.AppearanceHeader.Options.UseTextOptions = true;
            this.valueCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.valueCol.Caption = "Текущие значения";
            this.valueCol.FieldName = "CurrentValue";
            this.valueCol.Name = "valueCol";
            this.valueCol.OptionsColumn.AllowEdit = false;
            this.valueCol.Visible = true;
            this.valueCol.VisibleIndex = 1;
            this.valueCol.Width = 144;
            // 
            // curTimeCol
            // 
            this.curTimeCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.curTimeCol.AppearanceHeader.Options.UseFont = true;
            this.curTimeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.curTimeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.curTimeCol.Caption = "Время обновления";
            this.curTimeCol.FieldName = "LastUpdateTime";
            this.curTimeCol.Name = "curTimeCol";
            this.curTimeCol.OptionsColumn.AllowEdit = false;
            this.curTimeCol.Visible = true;
            this.curTimeCol.VisibleIndex = 2;
            this.curTimeCol.Width = 159;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.plcVarGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.Navy;
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl3.Controls.Add(this.plcVarGrid);
            this.groupControl3.Location = new System.Drawing.Point(346, 44);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(554, 485);
            this.groupControl3.TabIndex = 45;
            this.groupControl3.Text = "Просмотр текущих значений";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(888, 37);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.CloseButtonAffectAllTabs = false;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.connectPlcBtnItem,
            this.disconnectPlcBtnItem,
            this.listenDbBtnItem,
            this.listemStopDbBtnItem,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.connectPlcBtnItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.disconnectPlcBtnItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.listenDbBtnItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.listemStopDbBtnItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Tools";
            // 
            // connectPlcBtnItem
            // 
            this.connectPlcBtnItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.connectPlcBtnItem.Caption = "Подключить";
            this.connectPlcBtnItem.Glyph = ((System.Drawing.Image)(resources.GetObject("connectPlcBtnItem.Glyph")));
            this.connectPlcBtnItem.Id = 0;
            this.connectPlcBtnItem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectPlcBtnItem.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.connectPlcBtnItem.ItemAppearance.Normal.Options.UseFont = true;
            this.connectPlcBtnItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("connectPlcBtnItem.LargeGlyph")));
            this.connectPlcBtnItem.Name = "connectPlcBtnItem";
            this.connectPlcBtnItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.connectPlcBtnItem_ItemClick);
            // 
            // disconnectPlcBtnItem
            // 
            this.disconnectPlcBtnItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.disconnectPlcBtnItem.Caption = "Отключить";
            this.disconnectPlcBtnItem.Glyph = ((System.Drawing.Image)(resources.GetObject("disconnectPlcBtnItem.Glyph")));
            this.disconnectPlcBtnItem.Id = 1;
            this.disconnectPlcBtnItem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disconnectPlcBtnItem.ItemAppearance.Normal.Options.UseFont = true;
            this.disconnectPlcBtnItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("disconnectPlcBtnItem.LargeGlyph")));
            this.disconnectPlcBtnItem.Name = "disconnectPlcBtnItem";
            this.disconnectPlcBtnItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.disconnectPlcBtnItem_ItemClick);
            // 
            // listenDbBtnItem
            // 
            this.listenDbBtnItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.listenDbBtnItem.Caption = "Начать прослушивание";
            this.listenDbBtnItem.Glyph = ((System.Drawing.Image)(resources.GetObject("listenDbBtnItem.Glyph")));
            this.listenDbBtnItem.Id = 2;
            this.listenDbBtnItem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listenDbBtnItem.ItemAppearance.Normal.Options.UseFont = true;
            this.listenDbBtnItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("listenDbBtnItem.LargeGlyph")));
            this.listenDbBtnItem.Name = "listenDbBtnItem";
            this.listenDbBtnItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.listenDbBtnItem_ItemClick);
            // 
            // listemStopDbBtnItem
            // 
            this.listemStopDbBtnItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.listemStopDbBtnItem.Caption = "Завершить  прослушивание";
            this.listemStopDbBtnItem.Glyph = ((System.Drawing.Image)(resources.GetObject("listemStopDbBtnItem.Glyph")));
            this.listemStopDbBtnItem.Id = 3;
            this.listemStopDbBtnItem.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listemStopDbBtnItem.ItemAppearance.Normal.Options.UseFont = true;
            this.listemStopDbBtnItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("listemStopDbBtnItem.LargeGlyph")));
            this.listemStopDbBtnItem.Name = "listemStopDbBtnItem";
            this.listemStopDbBtnItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.listemStopDbBtnItem_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(912, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Size = new System.Drawing.Size(912, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(912, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // TestFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 578);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestFm";
            this.ShowIcon = false;
            this.Text = "Тестирование";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deviceTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeIconImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcVarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcVarGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList deviceTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraSplashScreen.SplashScreenManager testSplashManager;
        private DevExpress.XtraGrid.GridControl plcVarGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView plcVarGridView;
        private DevExpress.XtraGrid.Columns.GridColumn propertyCol;
        private DevExpress.XtraGrid.Columns.GridColumn valueCol;
        private DevExpress.XtraGrid.Columns.GridColumn curTimeCol;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem connectPlcBtnItem;
        private DevExpress.XtraBars.BarButtonItem disconnectPlcBtnItem;
        private DevExpress.XtraBars.BarButtonItem listenDbBtnItem;
        private DevExpress.Utils.ImageCollection treeIconImageCollection;
        private DevExpress.XtraBars.BarButtonItem listemStopDbBtnItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}