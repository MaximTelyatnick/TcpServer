
using log4net;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVM_WMS.SERVER.Infrastructure.Logger;
using TVM_WMS.SERVER.Interfaces;
using TVM_WMS.SERVER.Entities;
using TVM_WMS.SERVER.DTO;
using FirebirdSql.Data.FirebirdClient;
using Packet;

namespace TVM_WMS.SERVER.Services
{
    public class SettingsService : ISettingsService
    {
        private IUnitOfWork Database { get; set; }

        private IRepository<StoreBindings> StoreBindings;
        private IRepository<DeviceBindings> DeviceBindings;
        private IRepository<Devices> Devices;
        private IRepository<DeviceTypes> DeviceTypes;
        private IRepository<DeviceSettings> DeviceSettings;
        private IRepository<SettingKinds> SettingKinds;
        private IRepository<SettingTypes> SettingTypes;
        private IRepository<GlobalSettings> GlobalSettings;
        private IRepository<Alarms> Alarms;
        private IRepository<DataItems> DataItems;
        private IRepository<DataItemsQuery> DataItemsQuery;
        private IRepository<PlcTypes> PlcTypes;
        private IRepository<StoreNames> StoreNames;
        private IRepository<DeviceBindingSettings> DeviceBindingSettings;

        private IMapper mapper;
        //private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public SettingsService(IUnitOfWork uow)
        {
            Database = uow;

            StoreBindings = Database.GetRepository<StoreBindings>();
            DeviceBindings = Database.GetRepository<DeviceBindings>();
            Devices = Database.GetRepository<Devices>();
            DeviceTypes = Database.GetRepository<DeviceTypes>();
            DeviceSettings = Database.GetRepository<DeviceSettings>();
            SettingKinds = Database.GetRepository<SettingKinds>();
            SettingTypes = Database.GetRepository<SettingTypes>();
            GlobalSettings = Database.GetRepository<GlobalSettings>();
            Alarms = Database.GetRepository<Alarms>();
            DataItems = Database.GetRepository<DataItems>();
            DataItemsQuery = Database.GetRepository<DataItemsQuery>();
            PlcTypes = Database.GetRepository<PlcTypes>();
            StoreNames = Database.GetRepository<StoreNames>();
            DeviceBindingSettings = Database.GetRepository<DeviceBindingSettings>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoreBindings, StoreBindingsDTO>();
                cfg.CreateMap<StoreBindingsDTO, StoreBindings>();
                cfg.CreateMap<DeviceBindings, DeviceBindingsDTO>();
                cfg.CreateMap<DeviceBindingsDTO, DeviceBindings>();
                cfg.CreateMap<DevicesDTO, Devices>();
                cfg.CreateMap<Devices, DevicesDTO>();
                cfg.CreateMap<DeviceTypes, DeviceTypesDTO>();
                cfg.CreateMap<SettingKinds, SettingKindsDTO>();
                cfg.CreateMap<SettingTypes, SettingTypesDTO>();
                cfg.CreateMap<DeviceSettingsDTO, DeviceSettings>();
                cfg.CreateMap<Alarms, AlarmsDTO>();
                cfg.CreateMap<AlarmsDTO, Alarms>();
                cfg.CreateMap<DataItems, DataItemsDTO>();
                cfg.CreateMap<DataItemsDTO, DataItems>();
                cfg.CreateMap<PlcTypes, PlcTypesDTO>();
                cfg.CreateMap<PlcTypesDTO, PlcTypes>();
                cfg.CreateMap<DataItemsQuery, DataItemsQueryDTO>();
                cfg.CreateMap<GlobalSettings, GlobalSettingsDTO>();
                cfg.CreateMap<GlobalSettingsDTO, GlobalSettings>();
                cfg.CreateMap<DeviceBindingSettings, DeviceBindingSettingsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<SettingKindsDTO> GetSettingKinds()
        {
            return mapper.Map<IEnumerable<SettingKinds>, List<SettingKindsDTO>>(SettingKinds.GetAll());
        }

        public IEnumerable<DevicesDTO> GetDevices(string LocalCPUID)
        {
            return mapper.Map<IEnumerable<Devices>, List<DevicesDTO>>(Devices.GetAll().Where(s => s.LocalCPUID == LocalCPUID));
        }

        public IEnumerable<DeviceTypesDTO> GetDeviceTypes()
        {
            return mapper.Map<IEnumerable<DeviceTypes>, List<DeviceTypesDTO>>(DeviceTypes.GetAll());
        }

        public IEnumerable<PlcTypesDTO> GetPlcTypes()
        {
            return mapper.Map<IEnumerable<PlcTypes>, List<PlcTypesDTO>>(PlcTypes.GetAll());
        }

        public IEnumerable<StoreBindingsDTO> GetStoreBindings(string localCPUID)
        {
            var query = (from sb in StoreBindings.GetAll()
                         join sn in StoreNames.GetAll() on sb.StoreNameId equals sn.StoreNameId
                         join sn_j in StoreNames.GetAll() on sn.ParentId equals sn_j.StoreNameId
                         join db in DeviceBindings.GetAll() on sb.DeviceBindingId equals db.Id
                         join d in Devices.GetAll() on db.DeviceId equals d.Id
                         where d.LocalCPUID == localCPUID
                         select new StoreBindingsDTO()
                         {
                             Id = sb.Id,
                             DeviceBindingId = sb.DeviceBindingId,
                             StoreNameId = sb.StoreNameId,
                             Name = sn.Name + "(" + sn_j.Name + ")"
                         }
                );

            return query;
        }

        public IEnumerable<DeviceBindingSettingsDTO> GetDeviceBindingSettings(string localCPUID)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("LocalCPUID", localCPUID)
                 };

            string procName = @"select * from ""GetDeviceBindingSettings""(@LocalCPUID)";

            return mapper.Map<IEnumerable<DeviceBindingSettings>, List<DeviceBindingSettingsDTO>>(DeviceBindingSettings.SQLExecuteProc(procName, Parameters));
        }

        public IEnumerable<DataItemsQueryDTO> GetDataItemsQuery(string localCPUID)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("LocalCPUID", localCPUID)
                 };

            string procName = @"select * from ""GetDataItems""(@LocalCPUID)";

            return mapper.Map<IEnumerable<DataItemsQuery>, List<DataItemsQueryDTO>>(DataItemsQuery.SQLExecuteProc(procName, Parameters));
        }

        public IEnumerable<DeviceInfoDTO> GetDeviceSettings(string localCPUID)
        {
            var query = (from d in Devices.GetAll()
                         join dt in DeviceTypes.GetAll() on d.TypeId equals dt.Id into ddt
                         from dt in ddt.DefaultIfEmpty()
                         join ds in DeviceSettings.GetAll() on d.Id equals ds.DeviceId into dds
                         from ds in dds.DefaultIfEmpty()
                         join sk in SettingKinds.GetAll() on ds.SettingKindId equals sk.Id into dsk
                         from sk in dsk.DefaultIfEmpty()
                         where d.LocalCPUID == localCPUID
                         select new DeviceInfoDTO()
                         {
                             DeviceId = d.Id,
                             DeviceSettingId = ds.Id,
                             Name = d.Name,
                             LocalCPUID = d.LocalCPUID,
                             SettingKindId = ds.SettingKindId,
                             KindName = sk.KindName,
                             SettingValue = ds.SettingValue,
                             TypeId = d.TypeId,
                             TypeName = dt.TypeName,
                             TypeDescription = dt.TypeDescription,
                             Description = sk.Description
                         }
                         ).ToList();


            return query;
        }

        public IEnumerable<GlobalSettingsInfoDTO> GetGlobalSettings()
        {
            var query = (from st in SettingTypes.GetAll()
                         join gs in GlobalSettings.GetAll() on st.Id equals gs.SettingTypeId into stgs
                         from gs in stgs.DefaultIfEmpty()
                         join sk in SettingKinds.GetAll() on gs.SettingKindId equals sk.Id into gssk
                         from sk in gssk.DefaultIfEmpty()
                         select new GlobalSettingsInfoDTO()
                         {
                             Id = st.Id,
                             GlobalSettingId = gs.Id,
                             SettingSectionName = st.SettingSectionName,
                             SettingTypeId = gs.SettingTypeId,
                             SettingKindId = sk.Id,
                             KindName = sk.KindName,
                             SettingValue = gs.SettingValue,
                             Description = sk.Description
                         }
                         ).ToList();

            return query.Select(s => { s.Printable = bool.Parse(s.SettingValue); return s; });
        }

        public List<AlarmsDTO> GetAlarms()
        {
            return mapper.Map<IEnumerable<Alarms>, List<AlarmsDTO>>(Alarms.GetAll().OrderBy(a => a.AlarmNumber));
        }

        public int GetDeviceTypeIdByName(string typeName)
        {
            var entity = DeviceTypes.GetAll().SingleOrDefault(s => s.TypeName == typeName);
            return (entity != null) ? entity.Id : -1;
        }

        public int GetSettingKindIdByName(string kindName)
        {
            var entity = SettingKinds.GetAll().SingleOrDefault(s => s.KindName == kindName);
            return (entity != null) ? entity.Id : -1;
        }

        public void DevicePropertiesCreate(List<DeviceSettingsDTO> source)
        {
            if (source.Count > 0)
                DeviceSettings.CreateRange(mapper.Map<IEnumerable<DeviceSettings>>(source));
        }

        public void DevicePropertiesUpdate(List<DeviceSettingsDTO> source)
        {
            if (source.Count > 0)
            {
                foreach (var item in source)
                {
                    var entity = DeviceSettings.GetAll().SingleOrDefault(c => c.DeviceId == item.DeviceId && c.SettingKindId == item.SettingKindId);
                    item.Id = entity.Id;
                    DeviceSettings.Update(mapper.Map<DeviceSettingsDTO, DeviceSettings>(item, entity));
                }

            }
        }

        public void DataItemsCreate(List<DataItemsDTO> source)
        {
            if (source.Count > 0)
                DataItems.CreateRange(mapper.Map<IEnumerable<DataItems>>(source));
        }

        public void DataItemsUpdate(List<DataItemsDTO> source)
        {
            if (source.Count > 0)
            {
                foreach (var item in source)
                {
                    var entity = DataItems.GetAll().SingleOrDefault(c => c.Id == item.Id);
                    DataItems.Update(mapper.Map<DataItemsDTO, DataItems>(item, entity));
                }
            }
        }

        public int DeviceSettingCreate(DeviceSettingsDTO dsdto)
        {
            var newSetting = DeviceSettings.Create(mapper.Map<DeviceSettings>(dsdto));
            return newSetting.Id;
        }

        public void DeviceSettingUpdate(DeviceSettingsDTO dsdto)
        {
            var entity = DeviceSettings.GetAll().SingleOrDefault(c => c.Id == dsdto.Id);
            DeviceSettings.Update(mapper.Map<DeviceSettingsDTO, DeviceSettings>(dsdto, entity));
        }

        public void LabelSettingsUpdate(List<GlobalSettingsDTO> source)
        {
            if (source.Count > 0)
            {
                foreach (var item in source)
                {
                    var entity = GlobalSettings.GetAll().SingleOrDefault(c => c.Id == item.Id);
                    item.Id = entity.Id;
                    GlobalSettings.Update(mapper.Map<GlobalSettingsDTO, GlobalSettings>(item, entity));
                }

            }
        }

        public int DeviceCreate(DevicesDTO ddto)
        {
            var newDevice = Devices.Create(mapper.Map<Devices>(ddto));
            return newDevice.Id;
        }

        public void DeviceUpdate(DevicesDTO ddto)
        {
            var entity = Devices.GetAll().SingleOrDefault(c => c.Id == ddto.Id);
            Devices.Update(mapper.Map<DevicesDTO, Devices>(ddto, entity));
        }

        public bool DeviceDeleteWithProperties(int id)
        {
            try
            {
                var delDevice = Devices.GetAll().SingleOrDefault(c => c.Id == id);
                Devices.Delete(delDevice);
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                return false;
            }
        }

        public int DeviceBindingCreate(DeviceBindingsDTO dbdto)
        {
            var newBinding = DeviceBindings.Create(mapper.Map<DeviceBindings>(dbdto));
            return newBinding.Id;
        }

        public bool DeviceBindingDelete(int id)
        {
            try
            {
                var delBinding = DeviceBindings.GetAll().SingleOrDefault(c => c.Id == id);
                DeviceBindings.Delete(delBinding);
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                return false;
            }
        }

        public int StoreBindingCreate(StoreBindingsDTO sdto)
        {
            var newBinding = StoreBindings.Create(mapper.Map<StoreBindings>(sdto));
            return newBinding.Id;
        }

        public bool StoreBindingDelete(int id)
        {
            try
            {
                var delBinding = StoreBindings.GetAll().SingleOrDefault(c => c.Id == id);
                StoreBindings.Delete(delBinding);
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                return false;
            }
        }

        public int AlarmCreate(AlarmsDTO adto)
        {
            var newAlarm = Alarms.Create(mapper.Map<Alarms>(adto));
            return newAlarm.Id;
        }

        public void AlarmUpdate(AlarmsDTO adto)
        {
            var entity = Alarms.GetAll().SingleOrDefault(c => c.Id == adto.Id);
            Alarms.Update(mapper.Map<AlarmsDTO, Alarms>(adto, entity));
        }

        public bool AlarmDelete(AlarmsDTO adto)
        {
            try
            {
                Alarms.Delete(Alarms.GetAll().FirstOrDefault(c => c.Id == adto.Id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
