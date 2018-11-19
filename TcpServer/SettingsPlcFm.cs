using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.SERVER.Interfaces;
using Packet;
using TVM_WMS.SERVER.Infrastructure;
using TVM_WMS.SERVER.DTO;
using Ninject;


namespace TVM_WMS.SERVER
{
    public partial class SettingsPlcFm : DevExpress.XtraEditors.XtraForm
    {
        private ISettingsService settingsService;
        private BindingSource plcSettingsBS = new BindingSource();

        private Utils.Operation _operation;
        private int _deviceId;

        public ObjectBase Item
        {
            get { return plcSettingsBS.Current as ObjectBase; }
            set
            {
                plcSettingsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public SettingsPlcFm(Utils.Operation operation, ConfigClass.PlcSettingSource source)
        {
            InitializeComponent();

            _operation = operation;

            plcSettingsBS.DataSource = Item = source;

            nameTBox.DataBindings.Add("EditValue", plcSettingsBS, "Name");
            ipTBox.DataBindings.Add("EditValue", plcSettingsBS, "Ip");
            rackTBox.DataBindings.Add("EditValue", plcSettingsBS, "Rack");
            slotTBox.DataBindings.Add("EditValue", plcSettingsBS, "Slot");

            cpuTypeEdit.Properties.DataSource = Enum.GetValues(typeof(S7.Net.CpuType));
            cpuTypeEdit.Properties.ValueMember = "Column";
            cpuTypeEdit.DataBindings.Add("EditValue", plcSettingsBS, "CpuType");
        }

        #region Method's

        private bool ControlValidation()
        {
            return plcSettingValidationProvider.Validate();
        }

        public int Return()
        {
            return _deviceId;
        }

        private bool SavePlcSettings()
        {
            plcSettingsBS.EndEdit();

            settingsService = Program.kernel.Get<ISettingsService>();

            if (FindDeviceNameDuplicate((ConfigClass.PlcSettingSource)plcSettingsBS.Current))
            {
                MessageBox.Show("Устройство с таким именем уже используется для данного комп'ютера. Введите другое наименование.\n",
                                "Проверка уникальности наименования устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();

                return false;
            }

            if (_operation == Utils.Operation.Add)
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("PLC");
                _deviceId = settingsService.DeviceCreate(new DevicesDTO()
                {
                    Name = ((ConfigClass.PlcSettingSource)plcSettingsBS.Current).Name,
                    LocalCPUID = ConfigClass.Instance.LocalCPUID,
                    TypeId = deviceTypeId
                });

                if (_deviceId > 0)
                {
                    ((ConfigClass.PlcSettingSource)plcSettingsBS.Current).DeviceId = _deviceId;
                    var modelList = ConfigClass.Instance.ConvertPlcSettingsToModel(settingsService, (ConfigClass.PlcSettingSource)plcSettingsBS.Current);
                    settingsService.DevicePropertiesCreate(modelList);
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении нового устройства! Проверьте настройки подключения.\n", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("PLC");

                settingsService.DeviceUpdate(new DevicesDTO()
                {
                    Id = ((ConfigClass.PlcSettingSource)plcSettingsBS.Current).DeviceId,
                    Name = ((ConfigClass.PlcSettingSource)plcSettingsBS.Current).Name,
                    LocalCPUID = ConfigClass.Instance.LocalCPUID,
                    TypeId = deviceTypeId
                });

                var modelList = ConfigClass.Instance.ConvertPlcSettingsToModel(settingsService, (ConfigClass.PlcSettingSource)plcSettingsBS.Current);
                settingsService.DevicePropertiesUpdate(modelList);
            }

            return true;
        }

        private bool FindDeviceNameDuplicate(ConfigClass.PlcSettingSource item)
        {
            bool result = false;

            if (ConfigClass.Instance.PlcSettingList != null)
            {
                var source = (ConfigClass.Instance.PlcSettingList).FirstOrDefault(s => s.Name == item.Name);

                if (source != null)
                    result = (source.DeviceId != item.DeviceId) ? true : false;
            }

            return result;
        }

        #endregion

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            this.Item.EndEdit();

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SavePlcSettings())
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        #endregion

        #region Validation

        private void plcSettingValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void plcSettingValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (plcSettingValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            plcSettingValidationProvider.Validate((Control)sender);
        }

        private void ipTBox_TextChanged(object sender, EventArgs e)
        {
            plcSettingValidationProvider.Validate((Control)sender);
        }

        private void cpuTypeEdit_EditValueChanged(object sender, EventArgs e)
        {
            plcSettingValidationProvider.Validate((Control)sender);
        }

        private void rackTBox_TextChanged(object sender, EventArgs e)
        {
            plcSettingValidationProvider.Validate((Control)sender);
        }

        private void slotTBox_TextChanged(object sender, EventArgs e)
        {
            plcSettingValidationProvider.Validate((Control)sender);
        }
        
        #endregion

    }
}