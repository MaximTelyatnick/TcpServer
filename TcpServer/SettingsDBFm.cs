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
using System.Reflection;

namespace TVM_WMS.SERVER
{
    public partial class SettingsDBFm : DevExpress.XtraEditors.XtraForm
    {

        private ISettingsService settingsService;
        private BindingSource DBSettingsBS = new BindingSource();
        private BindingSource DBDeviceBS = new BindingSource(); private List<DataItemsQueryDTO> dataItemList = new List<DataItemsQueryDTO>();
        private Utils.Operation _operation;
        private int _deviceId;
        private int _parentDeviceId;
        private int _intervatSettingId;

        public SettingsDBFm(Utils.Operation operation, int deviceId, int parentDeviceId)
        {
            InitializeComponent();

            settingsService = Program.kernel.Get<ISettingsService>();

            _operation = operation;
            _deviceId = deviceId;
            _parentDeviceId = parentDeviceId;

            if (_operation == Utils.Operation.Add)
            {
                DBSettingsBS.DataSource = GetEmptyDataItemList();
                DBDeviceBS.DataSource = new DeviceInfoDTO();

                refreshSpin.EditValue = 1;
            }
            else
            {
                dataItemList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == _deviceId).ToList();
                DBSettingsBS.DataSource = dataItemList;

                DBDeviceBS.DataSource = ConfigClass.Instance.DeviceSettingsList.FirstOrDefault(s => s.DeviceId == _deviceId && s.KindName == "DataBlockIndex");

                var intervalSettingItem = ConfigClass.Instance.DeviceSettingsList.FirstOrDefault(s => s.DeviceId == _deviceId && s.KindName == "Interval");
                refreshSpin.EditValue = intervalSettingItem.SettingValue;
                _intervatSettingId = (int)intervalSettingItem.DeviceSettingId;
            }

            dbVarGrid.DataSource = DBSettingsBS;

            nameTBox.DataBindings.Add("EditValue", DBDeviceBS, "Name");
            dbIndexTBox.DataBindings.Add("EditValue", DBDeviceBS, "SettingValue");

            repositoryTypeNameEdit.DataSource = settingsService.GetPlcTypes();
            repositoryTypeNameEdit.DisplayMember = "TypeName";
            repositoryTypeNameEdit.ValueMember = "Id";
        }

        #region Method's

        private List<DataItemsQueryDTO> GetEmptyDataItemList()
        {
            PropertyInfo[] properties = typeof(PlcListenVar).GetProperties();
            foreach (PropertyInfo item in properties)
            {

                //DataItemsQueryDTO dataItems = new DataItemsQueryDTO(0, _deviceId, item.Name, false, _parentDeviceId, "0.0", 0, "", "", "", "", "");

                dataItemList.Add(new DataItemsQueryDTO()
                {
                    Name = item.Name,
                    Offset = "0.0",
                    ParentDeviceId = _parentDeviceId,
                    DeviceId = _deviceId
                });
            }

            //new DataItemsQueryDTO(0,_deviceId, item.Name,false,_parentDeviceId, "0.0",0,"","","","","")

            return dataItemList;
        }

        private bool ControlValidation()
        {
            return DBSettingValidationProvider.Validate();
        }

        private bool SaveDBSettings()
        {
            settingsService = Program.kernel.Get<ISettingsService>();

            if (FindDeviceNameDuplicate((DeviceInfoDTO)DBDeviceBS.Current, _parentDeviceId))
            {
                MessageBox.Show("Блок памяти таким именем уже используется для данного контроллера. Введите другое наименование.\n",
                                "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();

                return false;
            }

            DBSettingsBS.EndEdit();
            DBDeviceBS.EndEdit();

            int deviceTypeId = settingsService.GetDeviceTypeIdByName("DB");

            DevicesDTO entity = new DevicesDTO()
            {
                Id = _deviceId,
                Name = ((DeviceInfoDTO)DBDeviceBS.Current).Name,
                TypeId = deviceTypeId,
                LocalCPUID = ConfigClass.Instance.LocalCPUID
            };

            if (_operation == Utils.Operation.Add)
            {
                if (!dataItemList.Any(s => s.ItemTypeId == 0))
                {
                    _deviceId = settingsService.DeviceCreate(entity);

                    if (_deviceId > 0)
                    {
                        int skId = settingsService.GetSettingKindIdByName("DataBlockIndex");

                        settingsService.DeviceSettingCreate(new DeviceSettingsDTO()
                        {
                            DeviceId = _deviceId,
                            SettingKindId = skId,
                            SettingValue = ((DeviceInfoDTO)DBDeviceBS.Current).SettingValue
                        });

                        int iId = settingsService.GetSettingKindIdByName("Interval");

                        settingsService.DeviceSettingCreate(new DeviceSettingsDTO()
                        {
                            DeviceId = _deviceId,
                            SettingKindId = iId,
                            SettingValue = refreshSpin.EditValue.ToString()
                        });

                        dataItemList.ForEach(s => s.DeviceId = _deviceId);

                        var items = dataItemList.Select(s => new DataItemsDTO()
                        {
                            DeviceId = s.DeviceId,
                            ItemTypeId = s.ItemTypeId,
                            Name = s.Name,
                            Offset = s.Offset,
                            ParentDeviceId = s.ParentDeviceId,
                            CanListen = (s.CanListen) ? 1 : 0
                        }).ToList();

                        settingsService.DataItemsCreate(items);

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении нового устройства! Проверьте настройки подключения.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран тип данных для одной или нескольких переменных блока памяти!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                settingsService.DeviceUpdate(entity);

                var modelIndex = new DeviceSettingsDTO()
                {
                    Id = ((DeviceInfoDTO)DBDeviceBS.Current).DeviceSettingId ?? 0,
                    DeviceId = ((DeviceInfoDTO)DBDeviceBS.Current).DeviceId,
                    SettingKindId = settingsService.GetSettingKindIdByName("DataBlockIndex"),
                    SettingValue = ((DeviceInfoDTO)DBDeviceBS.Current).SettingValue
                };

                settingsService.DeviceSettingUpdate(modelIndex);

                var modelInterval = new DeviceSettingsDTO()
                {
                    Id = _intervatSettingId,
                    DeviceId = ((DeviceInfoDTO)DBDeviceBS.Current).DeviceId,
                    SettingKindId = settingsService.GetSettingKindIdByName("Interval"),
                    SettingValue = refreshSpin.EditValue.ToString()
                };

                settingsService.DeviceSettingUpdate(modelInterval);

                var items = dataItemList.Select(s => new DataItemsDTO()
                {
                    Id = s.Id,
                    DeviceId = s.DeviceId,
                    ItemTypeId = s.ItemTypeId,
                    Name = s.Name,
                    Offset = s.Offset,
                    ParentDeviceId = s.ParentDeviceId,
                    CanListen = (s.CanListen) ? 1 : 0
                }).ToList();

                settingsService.DataItemsUpdate(items);
            }

            return true;
        }

        private bool FindDeviceNameDuplicate(DeviceInfoDTO item, int parentDeviceId)
        {
            bool result = false;

            if (ConfigClass.Instance.DeviceSettingsList != null)
            {
                var source = (ConfigClass.Instance.DataItemList).FirstOrDefault(s => s.DeviceName == item.Name && s.ParentDeviceId == parentDeviceId);

                if (source != null)
                    result = (source.DeviceId != item.DeviceId) ? true : false;
            }

            return result;
        }

        public int Return()
        {
            return _deviceId;
        }

        #endregion

        private void DBSettingValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void DBSettingValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (DBSettingValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SaveDBSettings())
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repositoryTypeNameEdit_EditValueChanged(object sender, EventArgs e)
        {
            ((DataItemsQueryDTO)DBSettingsBS.Current).ItemTypeId = (int)((LookUpEdit)sender).EditValue;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            DBSettingValidationProvider.Validate((Control)sender);
        }

        private void dbIndexTBox_TextChanged(object sender, EventArgs e)
        {
            DBSettingValidationProvider.Validate((Control)sender);
        }

        private void refreshSpin_EditValueChanged(object sender, EventArgs e)
        {
            DBSettingValidationProvider.Validate((Control)sender);
        }


    }
}