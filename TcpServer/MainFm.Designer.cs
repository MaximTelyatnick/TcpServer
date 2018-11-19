namespace TVM_WMS.SERVER
{
    partial class MainFm
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
            this.serverIpEdit = new DevExpress.XtraEditors.TextEdit();
            this.startServerBtn = new DevExpress.XtraEditors.SimpleButton();
            this.messageEdit = new DevExpress.XtraEditors.MemoEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.startCommandBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.serverIpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // serverIpEdit
            // 
            this.serverIpEdit.Location = new System.Drawing.Point(6, 9);
            this.serverIpEdit.Name = "serverIpEdit";
            this.serverIpEdit.Size = new System.Drawing.Size(416, 22);
            this.serverIpEdit.TabIndex = 0;
            this.serverIpEdit.EditValueChanged += new System.EventHandler(this.serverIpEdit_EditValueChanged);
            // 
            // startServerBtn
            // 
            this.startServerBtn.Location = new System.Drawing.Point(428, 8);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(100, 23);
            this.startServerBtn.TabIndex = 1;
            this.startServerBtn.Text = "Запустить";
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // messageEdit
            // 
            this.messageEdit.Location = new System.Drawing.Point(6, 65);
            this.messageEdit.Name = "messageEdit";
            this.messageEdit.Size = new System.Drawing.Size(522, 439);
            this.messageEdit.TabIndex = 2;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(6, 37);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(416, 22);
            this.lookUpEdit1.TabIndex = 3;
            // 
            // startCommandBtn
            // 
            this.startCommandBtn.Location = new System.Drawing.Point(428, 36);
            this.startCommandBtn.Name = "startCommandBtn";
            this.startCommandBtn.Size = new System.Drawing.Size(100, 23);
            this.startCommandBtn.TabIndex = 4;
            this.startCommandBtn.Text = "Выполнить ";
            this.startCommandBtn.Click += new System.EventHandler(this.startCommandBtn_Click);
            // 
            // MainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 516);
            this.Controls.Add(this.startCommandBtn);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.messageEdit);
            this.Controls.Add(this.startServerBtn);
            this.Controls.Add(this.serverIpEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFm";
            this.ShowIcon = false;
            this.Text = "Управление сервером";
            ((System.ComponentModel.ISupportInitialize)(this.serverIpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit serverIpEdit;
        private DevExpress.XtraEditors.SimpleButton startServerBtn;
        private DevExpress.XtraEditors.MemoEdit messageEdit;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton startCommandBtn;
    }
}