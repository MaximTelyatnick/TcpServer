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

using Ninject;
using TVM_WMS.SERVER.Infrastructure;
using TVM_WMS.SERVER.Interfaces;
using System.IO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using TVM_WMS.SERVER.DTO;
using Packet;
using TVM_WMS.SERVER.Infrastructure.Logger;
using WatsonTcp;
using TVM_WMS.SERVER.Infrastructure.FormConnect;

namespace TVM_WMS.SERVER
{
    public partial class SettingsFm : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler<UserEventArgs> sendDataFromFormEvent;

        //public event EventHandler<UserEventArgs> sendDataFromFormEvent;

        private ISettingsService settingsService;

        private BindingSource dataItemBS = new BindingSource();

        private PLC plc;

        private string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private string config;

        public SettingsFm()
        {
            InitializeComponent();

            config = HomePath + @"\Settings.xml";
        
            settingsSplashManager.ShowWaitForm();

            fotterContainer.Height = 200;

            LoadConfiguration();
            
            settingsSplashManager.CloseWaitForm();

        }

        #region DataBase settings

        private string GetConnectionStringFromTestValue()
        {
            //string testConnectionString = "User=SYSDBA; Password=masterkey; " +
            //                              "DataBase=" + dbFilePathTBox.Text + "; " +
            //                              "Server=" + dbIpTBox.Text + "; " +
            //                              "Dialect=3; Charset=UTF8";

            string testConnectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3; Charset=UTF8";

            return testConnectionString;
        }

        private void testDbBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Program.kernel = new StandardKernel(new ServiceModule(GetConnectionStringFromTestValue()));
                MessageBox.Show("Соединение успешно!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при соединении! \n" + ex.Message, "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        #endregion

        #region Form method's

        private void LoadConfiguration()
        {
            ConfigClass.Instance.GetLocaSettings(config);

            try
            {
                Program.kernel = new StandardKernel(new ServiceModule(ConfigClass.Instance.ConnectionDbString));
                settingsService = Program.kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigLoad(settingsService);
                serverIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.GeneralServerIp ?? "";
                serverPortTBox.Text = ConfigClass.Instance.GlobalLocalSettings.GeneralServerPort ?? "";
                dbFilePathTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbAlias ?? "";
                dbIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbServerName ?? "";
                logFileTBox.Text = ConfigClass.Instance.GlobalLocalSettings.LogFilePath ?? "";
                numberSaveLogEdit.Text = ConfigClass.Instance.GlobalLocalSettings.LogSaveDay.ToString();
                exportReceiptXMLTBox.Text = ConfigClass.Instance.GlobalLocalSettings.ReceiptXMLPath ?? "";
                exportExpenditureXMLTBox.Text = ConfigClass.Instance.GlobalLocalSettings.ExpenditureXMLPath ?? "";
                watchOffsetEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset ?? "";
                watchDogDbNameEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName ?? "";

                var bindTreeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                var bindTreeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();

                CreateDeviceNodes(deviceTree);
                deviceTree.ExpandAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при инициализации базы данных! Проверьте настройки подключения.\n" + ex.Message, "Загрузка настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbFilePathTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbAlias ?? "";
                dbIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbServerName ?? "";

                //settingsTab.SelectedTabPage = basePage;
            }

        }


        private void CreateDeviceNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();

            int imageIndex = -1;

            settingsService = Program.kernel.Get<ISettingsService>();
            var deviceTypes = settingsService.GetDeviceTypes().Where(dt => (dt.TypeName == "PLC" || dt.TypeName == "DB"));
            var devices = settingsService.GetDevices(ConfigClass.Instance.LocalCPUID);


            foreach (var typeItem in deviceTypes)
            {
                switch (typeItem.TypeName)
                {
                    case "PLC":
                        imageIndex = 5;
                        break;
                    //case "BarcodeScanner":
                    //    imageIndex = 6;
                    //    break;
                    //case "Stacker":
                    //    imageIndex = 1;
                    //    break;
                    //case "DropoffWindow":
                    //    imageIndex = 2;
                    //    break;
                    default:
                        break;
                }

                if (typeItem.TypeName != "DB")
                {
                    TreeListNode parentForRootNodes = null;
                    TreeListNode rootNode = tl.AppendNode(new object[] { typeItem.TypeDescription }, parentForRootNodes);

                    rootNode.StateImageIndex = imageIndex;
                    rootNode.Tag = typeItem.Id;



                    var childDeviceList = devices.Where(s => s.TypeId == typeItem.Id);

                    foreach (var deviceItem in childDeviceList)
                    {
                        TreeListNode childNode = tl.AppendNode(new object[] { deviceItem.Name }, rootNode);
                        childNode.Tag = deviceItem.Id;
                        childNode.StateImageIndex = 7;

                        if (typeItem.TypeName == "PLC")
                        {
                            var childPLCList = ConfigClass.Instance.DataItemList.Where(w => w.ParentDeviceId == deviceItem.Id).Select(s => new { s.DeviceId, s.DeviceName }).Distinct().ToList();

                            if (childPLCList.Count() > 0)
                            {
                                foreach (var dbItem in childPLCList)
                                {
                                    TreeListNode childPLCNode = tl.AppendNode(new object[] { dbItem.DeviceName }, childNode);
                                    childPLCNode.Tag = dbItem.DeviceId;
                                    childPLCNode.StateImageIndex = 0;
                                }
                            }
                        }
                    }
                }
            }

            tl.EndUnboundLoad();
        }

        private bool EditPlcConfig(Utils.Operation operation, ConfigClass.PlcSettingSource model)
        {
            using (SettingsPlcFm plcEditFm = new SettingsPlcFm(operation, model))
            {
                if (plcEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingsSplashManager.ShowWaitForm();

                    int return_DeviceId = plcEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingsSplashManager.CloseWaitForm();

                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        private bool EditDataItemsConfig(Utils.Operation operation, int deviceId, int parentDeviceId)
        {
            using (SettingsDBFm dataItemsEditFm = new SettingsDBFm(operation, deviceId, parentDeviceId))
            {
                if (dataItemsEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingsSplashManager.ShowWaitForm();

                    int return_DeviceId = dataItemsEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingsSplashManager.CloseWaitForm();

                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        private bool SaveConfiguration()
        {
            try
            {

                settingsSplashManager.ShowWaitForm();

                string connectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3";

                ConfigClass.Instance.ConnectionDbString = connectionString;
                ConfigClass.Instance.GlobalLocalSettings.GeneralServerIp = serverIpTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.GeneralServerPort = serverPortTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.DbServerName = dbIpTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.DbAlias = dbFilePathTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.LogFilePath = logFileTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.LogSaveDay = Convert.ToInt16(numberSaveLogEdit.Text);
                ConfigClass.Instance.GlobalLocalSettings.ReceiptXMLPath = exportReceiptXMLTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.ExpenditureXMLPath = exportExpenditureXMLTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset = watchOffsetEdit.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName = watchDogDbNameEdit.Text;

                ConfigClass.Instance.SetLocalSettings(config);

                Program.kernel = new StandardKernel(new ServiceModule(connectionString));
                settingsService = Program.kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigSave();

                ConfigClass.Instance.ConfigLoad(settingsService);

                MessageBox.Show("Обновление информации успешно!", "Обновление информации", MessageBoxButtons.OK, MessageBoxIcon.Information);

                settingsSplashManager.CloseWaitForm();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении!\n" + ex.Message, "Обновление информации", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

        }

        public bool SendDataForm(FormCommandDTO formCommandDTO)
        {
            if (sendDataFromFormEvent != null)
            {
                sendDataFromFormEvent(this, new UserEventArgs(formCommandDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Event's


        private void deviceTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (deviceTree.Nodes.Count > 0)
            {
                bool canVisible = (deviceTree.FocusedNode.Level >= 1);

                editDeviceBtn.Enabled = canVisible;
                deleteDeviceBtn.Enabled = canVisible;
                addPlcItem.Enabled = !canVisible;

                bool isPLC = (deviceTree.FocusedNode.Tag == null) ? false : ConfigClass.Instance.PlcSettingList.Any(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);

                addDbBtn.Enabled = (canVisible && isPLC);

                switch (deviceTree.FocusedNode.Level)
                {
                    case 1:
                        propertyGrid.BeginUpdate();
                        propertyGrid.DataSource = ConfigClass.Instance.DeviceSettingsList.Where(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);
                        propertyGrid.EndUpdate();
                        break;
                    case 2:
                        propertyGrid.BeginUpdate();

                        var settingDBList = ConfigClass.Instance.DeviceSettingsList.Where(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);
                        var settingDataItemList = ConfigClass.Instance.DataItemList.Where(w => w.DeviceId == (int)deviceTree.FocusedNode.Tag).Select(s => new DeviceInfoDTO() { KindName = s.Name, SettingValue = (s.AbsoleteItemName + "(" + s.TypeName + ")"), Description = ((s.CanListen) ? "включено" : "отключено") });
                        propertyGrid.DataSource = settingDBList.Union(settingDataItemList).ToList();

                        propertyGrid.EndUpdate();
                        break;
                    default:
                        propertyGrid.DataSource = null;
                        break;
                }
            }
        }

        private void addPlcItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditPlcConfig(Utils.Operation.Add, new ConfigClass.PlcSettingSource()))
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "Контроллер добавлено."));
            else
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "Контроллер не добавлено."));
        }

        private void addDbBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditDataItemsConfig(Utils.Operation.Add, -1, (int)deviceTree.FocusedNode.Tag))
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "DB добавлено."));
            else
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "DB  не добавлено."));

        }

        private void editDeviceBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int focusedTagId = (int)deviceTree.FocusedNode.Tag;

            string deviceType = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.DeviceId == focusedTagId).TypeName;

            switch (deviceType)
            {
                case "PLC":
                    var plcSource = (ConfigClass.Instance.PlcSettingList).First(s => s.DeviceId == focusedTagId);
                    if(EditPlcConfig(Utils.Operation.Update, plcSource))
                        SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "Контроллер отредактирован."));
                    else
                        SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "Контроллер не отредактирован."));
                    break;

                case "DB":
                    int parentDeviceId = ConfigClass.Instance.DataItemList.First(s => s.DeviceId == focusedTagId).ParentDeviceId;
                    if(EditDataItemsConfig(Utils.Operation.Update, focusedTagId, parentDeviceId))
                        SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "DB отредактирован."));
                    else
                        SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "DB не отредактирован."));
                    break;

                default:
                    break;
            }
        }

        private void deleteDeviceBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int focusedTagId = (int)deviceTree.FocusedNode.Tag;

            string deviceType = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.DeviceId == focusedTagId).TypeName;

            switch (deviceType)
            {
                case "PLC":
                    if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isHaveDB = (ConfigClass.Instance.DataItemList).Any(s => s.ParentDeviceId == focusedTagId);
                        if (!isHaveDB)
                        {
                            settingsService.DeviceDeleteWithProperties(focusedTagId);
                            SendDataForm(new FormCommandDTO(Utils.TypeCommand.Inform, null, "Контроллер удалено."));

                            break;
                        }
                        else
                        {
                            MessageBox.Show("У контроллера имеются в настройках блоки памяти (DB).\n Удалите сначала блоки памяти.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else
                    {
                        return;
                    }

                default:
                    if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        settingsService.DeviceDeleteWithProperties(focusedTagId);
                        break;
                    }
                    else
                    {
                        return;
                    }
            }

            settingsSplashManager.ShowWaitForm();

            deviceTree.Nodes.Clear();

            settingsService = Program.kernel.Get<ISettingsService>();
            ConfigClass.Instance.ConfigLoad(settingsService);

            CreateDeviceNodes(deviceTree);

            deviceTree.ExpandAll();

            settingsSplashManager.CloseWaitForm();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
            SendDataForm(new FormCommandDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Reload,""));
        }

        #endregion

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            if (ConfigClass.Instance.server == null)
            {
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Start,""));
                if (ConfigClass.Instance.server != null)
                    startServerBtn.Text = "Остановить";

            }
            else
            {
                SendDataForm(new FormCommandDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Stop, ""));
                if (ConfigClass.Instance.server == null)
                    startServerBtn.Text = "Запустить";
            }
            
        }

        


    }
}