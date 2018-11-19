using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Management;
using System.IO.Ports;
using System.Reflection;
using S7.Net;
using TVM_WMS.SERVER.DTO;
using TVM_WMS.SERVER.Interfaces;
using TVM_WMS.SERVER.Infrastructure;
using System.Management;
using WatsonTcp;
using Packet;
//using TVM_WMS.BLL.Infrastructure.Logger;

namespace TVM_WMS.SERVER.Infrastructure
{
    [Serializable]    
    public class ConfigClass
    {

        public class PlcSettingSource : ObjectBase
        {
            public int DeviceId { get; set; }
            public string Name { get; set; }
            public string Ip { get; set; }
            public CpuType CpuType { get; set; }
            public short Rack { get; set; }
            public short Slot { get; set; }
        };

        public class GlobalLocalSettingsSource
        {
            public string DbServerName { get; set; }
            public string DbAlias { get; set; }
            public string GeneralServerIp { get; set; }
            public string GeneralServerPort { get; set; }
            public bool LogFileCheck { get; set; }
            public string LogFilePath { get; set; }
            public int LogSaveDay { get; set; }
            public string ReceiptXMLPath { get; set; }
            public string ExpenditureXMLPath { get; set; }
            public string WatchDogPLCOffset { get; set; }
            public string WatchDogPCOffset { get; set; }
            public string WatchDogDBName { get; set; }
            public string WatchDogPLCName { get; set; }

        };

        public class BindedWindowItem 
        {
            public int ItemId { get; set; }
            public int? ParentItemId { get; set; }
            public int DeviceId { get; set; }
            public int WindowNumber { get; set; }
            public int StoreNameId { get; set; }
            public int StoreNameParentId { get; set; }
            public bool BusyWindow { get; set; } 
        };



        public List<PlcSettingSource> PlcSettingList { get; internal set; }
        public GlobalLocalSettingsSource GlobalLocalSettings { get; internal set; }
        public List<DeviceBindingSettingsDTO> DeviceBindingSettingList { get; internal set; }
        public List<AlarmsDTO> AlarmList { get; internal set; }
        public List<DataItemsQueryDTO> DataItemList { get; internal set; }
        public List<DeviceInfoDTO> DeviceSettingsList { get; internal set; }
        public List<GlobalSettingsInfoDTO> GlobalSettingsList { get; internal set; }
        public List<BindedWindowItem> BindedWindowItemList { get; internal set; }

        public string ConnectionDbString { get; set; }

        public string ConnectionServerIpString { get; set; }
        public string ConnectionServerPortString { get; set; }
        
        public string LocalCPUID { get; set; }

        public WatsonTcpServer server { get; set; }

        private ISettingsService settingService;

        private static readonly Lazy<ConfigClass> _instance = new Lazy<ConfigClass>(() => new ConfigClass());

        public static ConfigClass Instance
        {
            get
            {
               return _instance.Value;
            }
        }

        public void ConfigLoad(ISettingsService service)
        {
            settingService = service;
            
            GetLocalCPUID();
                        
            var source = settingService.GetDeviceSettings(LocalCPUID);
            var sourceGlobalSettings = settingService.GetGlobalSettings();
            
            DeviceSettingsList = source.ToList();
            GlobalSettingsList = sourceGlobalSettings.ToList();
            
            AlarmList = settingService.GetAlarms();
            GetPlcSettings(source.Where(s => s.TypeId == 1).ToList());
            //GetBarcodeSettings(source.Where(s => s.TypeId == 2).ToList());
                        
            DeviceBindingSettingList = settingService.GetDeviceBindingSettings(LocalCPUID).ToList();
            DataItemList = settingService.GetDataItemsQuery(LocalCPUID).ToList();
           settingService.GetDataItemsQuery(LocalCPUID).ToList();

            BindedWindowItemList = DeviceBindingSettingList.Where(s => s.TypeName == "DropoffWindow").Select(w => new BindedWindowItem()
            {
                ItemId = w.Id,
                ParentItemId = w.ParentId,
                DeviceId = w.DeviceId,
                WindowNumber = Int32.Parse(w.SettingValue),
                StoreNameId = w.StoreNameId,
                StoreNameParentId = w.StoreNameParentId,
                BusyWindow = false
            }).ToList();

            //Logger.LogControl(GlobalLocalSettings.LogSaveDay);
                                        
        }
        
        private void GetLocalCPUID()
        {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                LocalCPUID = managObj.Properties["processorID"].Value.ToString();
                break;
            }        
        }

        /*private void GetBarcodeSettings(List<DeviceInfoDTO> barcodeSource)
        {
            if (barcodeSource.Count > 0)
            {
                List<BarcodeSettingSource> resultList = new List<BarcodeSettingSource>();

                var deviceUniqueList = barcodeSource.Select(s => s.DeviceId).Distinct().ToList();

                for (int i = 0; i < deviceUniqueList.Count; i++)
                {
                    var loopSource = barcodeSource.Where(s => s.DeviceId == (int)deviceUniqueList[i]);

                    resultList.Add(new BarcodeSettingSource()
                        {
                            DeviceId = loopSource.FirstOrDefault().DeviceId,
                            Name = loopSource.FirstOrDefault().Name,
                            PortName = loopSource.FirstOrDefault(s => s.KindName == "PortName").SettingValue,
                            BaudRate = Int32.Parse(loopSource.FirstOrDefault(s => s.KindName == "BaudRate").SettingValue),
                            DataBits = Int32.Parse(loopSource.FirstOrDefault(s => s.KindName == "DataBits").SettingValue),
                            Parity = (Parity)Enum.Parse(typeof(Parity), loopSource.FirstOrDefault(s => s.KindName == "Parity").SettingValue),
                            StopBits = (StopBits)Enum.Parse(typeof(StopBits), loopSource.FirstOrDefault(s => s.KindName == "StopBits").SettingValue)
                        });
                }

                BarcodeSettingList = resultList;
            }
            else
            {
                BarcodeSettingList = new List<BarcodeSettingSource>();
            }
            
        }
        */
        /* 
        public List<DeviceSettingsDTO> ConvertBarcodeSettingsToModel(ISettingsService service, BarcodeSettingSource currentSettings)
        {
            List<DeviceSettingsDTO> result = new List<DeviceSettingsDTO>();

            var kindsList = service.GetSettingKinds().ToList();

            PropertyInfo[] properties = typeof(BarcodeSettingSource).GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if (item.Name != "DeviceId" && item.Name != "Name")
                {
                    result.Add(new DeviceSettingsDTO()
                    {
                        DeviceId = currentSettings.DeviceId,
                        SettingKindId = kindsList.SingleOrDefault(s => s.KindName == item.Name).Id,
                        SettingValue = item.GetValue(currentSettings).ToString()
                    });
                }
            }

            return result;
        }
        */
        public List<DeviceSettingsDTO> ConvertPlcSettingsToModel(ISettingsService service, PlcSettingSource currentSettings)
        {
            List<DeviceSettingsDTO> result = new List<DeviceSettingsDTO>();

            var kindsList = service.GetSettingKinds().ToList();

            PropertyInfo[] properties = typeof(PlcSettingSource).GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if (item.Name != "DeviceId" && item.Name != "Name")
                {
                    result.Add(new DeviceSettingsDTO()
                    {
                        DeviceId = currentSettings.DeviceId,
                        SettingKindId = kindsList.SingleOrDefault(s => s.KindName == item.Name).Id,
                        SettingValue = item.GetValue(currentSettings).ToString()
                    });
                }
            }

            return result;
        }

        private void GetPlcSettings(List<DeviceInfoDTO> plcSource)
        {
            if (plcSource.Count > 0)
            {
                List<PlcSettingSource> resultList = new List<PlcSettingSource>();

                var deviceUniqueList = plcSource.Select(s => s.DeviceId).Distinct().ToList();

                for (int i = 0; i < deviceUniqueList.Count; i++)
                {
                    var loopSource = plcSource.Where(s => s.DeviceId == (int)deviceUniqueList[i]);

                    resultList.Add(new PlcSettingSource()
                    {
                        DeviceId = loopSource.FirstOrDefault().DeviceId,
                        Name = loopSource.FirstOrDefault().Name,
                        Ip = loopSource.FirstOrDefault(s => s.KindName == "Ip").SettingValue,
                        CpuType = (CpuType)Enum.Parse(typeof(CpuType), loopSource.FirstOrDefault(s => s.KindName == "CpuType").SettingValue),
                        Rack = Int16.Parse(loopSource.FirstOrDefault(s => s.KindName == "Rack").SettingValue),
                        Slot = Int16.Parse(loopSource.FirstOrDefault(s => s.KindName == "Slot").SettingValue)
                    });
                }

                PlcSettingList = resultList;
            }
        }

        public void GetLocaSettings(string myConfigFileName)
        {
            if (!File.Exists(myConfigFileName))
            {
                return;
            }

            XmlSerializer mySerializer = new XmlSerializer(typeof(GlobalLocalSettingsSource));
            //XmlSerializer mySerializer4 = new XmlSerializer(typeof(GlobalLocalSettingsSource));

            using (StreamReader myXmlReader = new StreamReader(myConfigFileName))
            {
                try
                {
                    GlobalLocalSettingsSource dbConfigClass = (GlobalLocalSettingsSource)mySerializer.Deserialize(myXmlReader);
                    //GlobalLocalSettingsSource globalLocalSettingsSource = (GlobalLocalSettingsSource)mySerializer4.Deserialize(myXmlReader);

                    GlobalLocalSettings = dbConfigClass;


                    ConnectionDbString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + GlobalLocalSettings.DbAlias + "; " +
                                          "Server=" + GlobalLocalSettings.DbServerName + "; " +
                                          "Dialect=3; Charset=UTF8";


                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при загрузке конфигурации программы\n" + e.ToString());
                    ConnectionDbString = null;
                }
            }

        }

        public void SetLocalSettings(string meConfigurationName)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(GlobalLocalSettingsSource));
            using (StreamWriter myXmlWriter = new StreamWriter(meConfigurationName))
            {
                try
                {
                    mySerializer.Serialize(myXmlWriter, GlobalLocalSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении конфигурации программы\n" + ex.ToString());
                }
            }
        }



        public void ConfigSave()
        {
            
        }
    }
}
