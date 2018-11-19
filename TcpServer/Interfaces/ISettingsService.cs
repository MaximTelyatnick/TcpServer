using Packet;
using System.Collections.Generic;
using TVM_WMS.SERVER;
using TVM_WMS.SERVER.DTO;

namespace TVM_WMS.SERVER.Interfaces
{
    public interface ISettingsService
    {
        IEnumerable<DeviceInfoDTO> GetDeviceSettings(string LocalCPUID);
        IEnumerable<DeviceBindingSettingsDTO> GetDeviceBindingSettings(string LocalCPUID);
        IEnumerable<StoreBindingsDTO> GetStoreBindings(string localCPUID);
        IEnumerable<GlobalSettingsInfoDTO> GetGlobalSettings();
        IEnumerable<SettingKindsDTO> GetSettingKinds();
        List<AlarmsDTO> GetAlarms();
        IEnumerable<PlcTypesDTO> GetPlcTypes();
        IEnumerable<DevicesDTO> GetDevices(string LocalCPUID);
        IEnumerable<DeviceTypesDTO> GetDeviceTypes();
        IEnumerable<DataItemsQueryDTO> GetDataItemsQuery(string LocalCPUID);

        int GetDeviceTypeIdByName(string typeName);
        int GetSettingKindIdByName(string kindName);

        void DevicePropertiesCreate(List<DeviceSettingsDTO> source);
        void DevicePropertiesUpdate(List<DeviceSettingsDTO> source);

        void LabelSettingsUpdate(List<GlobalSettingsDTO> source);

        int DeviceCreate(DevicesDTO ddto);
        void DeviceUpdate(DevicesDTO ddto);
        bool DeviceDeleteWithProperties(int id);

        int DeviceBindingCreate(DeviceBindingsDTO dbdto);
        bool DeviceBindingDelete(int id);

        int StoreBindingCreate(StoreBindingsDTO sdto);
        bool StoreBindingDelete(int id);

        int DeviceSettingCreate(DeviceSettingsDTO dsdto);
        void DeviceSettingUpdate(DeviceSettingsDTO dsdto);

        void DataItemsCreate(List<DataItemsDTO> source);
        void DataItemsUpdate(List<DataItemsDTO> source);

        int AlarmCreate(AlarmsDTO adto);
        void AlarmUpdate(AlarmsDTO adto);
        bool AlarmDelete(AlarmsDTO adto);

        void Dispose();
    }
}
