namespace TVM_WMS.SERVER
{
    partial class SettingsPlcFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.slotTBox = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.rackTBox = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.ipTBox = new DevExpress.XtraEditors.TextEdit();
            this.cpuTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.plcSettingValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTypeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcSettingValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(168, 24);
            this.nameTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.nameTBox.Properties.Mask.ShowPlaceHolders = false;
            this.nameTBox.Size = new System.Drawing.Size(353, 22);
            this.nameTBox.TabIndex = 79;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Не указан параметр";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.plcSettingValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 80;
            this.label1.Text = "Наименование";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 17);
            this.label12.TabIndex = 78;
            this.label12.Text = "Тип процессора";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 17);
            this.label11.TabIndex = 77;
            this.label11.Text = "Слот(Slot)";
            // 
            // slotTBox
            // 
            this.slotTBox.Location = new System.Drawing.Point(168, 152);
            this.slotTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.slotTBox.Name = "slotTBox";
            this.slotTBox.Properties.Mask.EditMask = "n0";
            this.slotTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.slotTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.slotTBox.Properties.Mask.ShowPlaceHolders = false;
            this.slotTBox.Size = new System.Drawing.Size(353, 22);
            this.slotTBox.TabIndex = 74;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Не указан параметр";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.plcSettingValidationProvider.SetValidationRule(this.slotTBox, conditionValidationRule2);
            this.slotTBox.TextChanged += new System.EventHandler(this.slotTBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "Стойка(Rack)";
            // 
            // rackTBox
            // 
            this.rackTBox.Location = new System.Drawing.Point(168, 120);
            this.rackTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rackTBox.Name = "rackTBox";
            this.rackTBox.Properties.Mask.EditMask = "n0";
            this.rackTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.rackTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rackTBox.Properties.Mask.ShowPlaceHolders = false;
            this.rackTBox.Size = new System.Drawing.Size(353, 22);
            this.rackTBox.TabIndex = 73;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Не указан параметр";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.plcSettingValidationProvider.SetValidationRule(this.rackTBox, conditionValidationRule3);
            this.rackTBox.TextChanged += new System.EventHandler(this.rackTBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 75;
            this.label7.Text = "IP адрес контроллера";
            // 
            // ipTBox
            // 
            this.ipTBox.Location = new System.Drawing.Point(168, 56);
            this.ipTBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ipTBox.Name = "ipTBox";
            this.ipTBox.Properties.Mask.EditMask = "([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\\.([0-9]|[1-9][0-9]|1[0-9][0-9" +
    "]|2[0-4][0-9]|25[0-5])){3}";
            this.ipTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.ipTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.ipTBox.Properties.Mask.ShowPlaceHolders = false;
            this.ipTBox.Size = new System.Drawing.Size(353, 22);
            this.ipTBox.TabIndex = 71;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Не указан параметр";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.plcSettingValidationProvider.SetValidationRule(this.ipTBox, conditionValidationRule4);
            this.ipTBox.TextChanged += new System.EventHandler(this.ipTBox_TextChanged);
            // 
            // cpuTypeEdit
            // 
            this.cpuTypeEdit.Location = new System.Drawing.Point(168, 88);
            this.cpuTypeEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cpuTypeEdit.Name = "cpuTypeEdit";
            this.cpuTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpuTypeEdit.Properties.NullText = "";
            this.cpuTypeEdit.Properties.PopupSizeable = false;
            this.cpuTypeEdit.Size = new System.Drawing.Size(353, 22);
            this.cpuTypeEdit.TabIndex = 72;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "Не указан параметр";
            conditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.plcSettingValidationProvider.SetValidationRule(this.cpuTypeEdit, conditionValidationRule5);
            this.cpuTypeEdit.EditValueChanged += new System.EventHandler(this.cpuTypeEdit_EditValueChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(339, 213);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(87, 28);
            this.saveBtn.TabIndex = 81;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(434, 213);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(87, 28);
            this.closeBtn.TabIndex = 82;
            this.closeBtn.Text = "Отмена";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // plcSettingValidationProvider
            // 
            this.plcSettingValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.plcSettingValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.plcSettingValidationProvider_ValidationFailed);
            this.plcSettingValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.plcSettingValidationProvider_ValidationSucceeded);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 219);
            this.validateLbl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(307, 16);
            this.validateLbl.TabIndex = 83;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // SettingsPlcFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(538, 250);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.slotTBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rackTBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ipTBox);
            this.Controls.Add(this.cpuTypeEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsPlcFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать настройки контролера";
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTypeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcSettingValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit nameTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit slotTBox;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit rackTBox;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit ipTBox;
        private DevExpress.XtraEditors.LookUpEdit cpuTypeEdit;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider plcSettingValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
    }
}