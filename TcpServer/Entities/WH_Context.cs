using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FirebirdSql.Data.FirebirdClient;


namespace TVM_WMS.SERVER.Entities
{
    public static class Connection
    {
        public static string ConnectionString;
    }

    public class WH_Context : DbContext
    {
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<WareHouses> WareHouses { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<MaterialGroups> MaterialGroups { get; set; }
        public DbSet<StoreNames> StoreNames { get; set; }
        public DbSet<Measures> Measures { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Contractors> Contractors { get; set; }
        public DbSet<PackingTypes> PackingTypes { get; set; }
        public DbSet<CellZones> CellZones { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public DbSet<Keepings> Keepings { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<EnumerationTypes> EnumerationTypes { get; set; }
        public DbSet<StorageGroups> StorageGroups { get; set; }
        public DbSet<ZoneNames> ZoneNames { get; set; }
        public DbSet<ZoneTypes> ZoneTypes { get; set; }
        public DbSet<StorageGroupZones> StorageGroupZones { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<CellInfo> CellInfo { get; set; }
        public DbSet<ReceiptsForKeeping> ReceiptsForKeeping { get; set; }
        public DbSet<CellPresence> CellPresence { get; set; }
        public DbSet<WareHouseCellsInfo> WareHouseCellsInfo { get; set; }
        public DbSet<StorageGroupsByZones> StorageGroupsByZones { get; set; }
        public DbSet<StorageGroupZonePresence> StorageGroupZonePresence { get; set; }
        public DbSet<RequirementMaterials> RequirementMaterials { get; set; }
        public DbSet<RequirementOrders> RequirementOrders { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Professions> Professions { get; set; }
        public DbSet<KeepingMaterials> KeepingMaterials { get; set; }
        public DbSet<ReceiptAcceptances> ReceiptAcceptances { get; set; }
        public DbSet<SettingKinds> SettingKinds { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<DeviceTypes> DeviceTypes { get; set; }
        public DbSet<DeviceSettings> DeviceSettings { get; set; }
        public DbSet<StoreBindings> StoreBindings { get; set; }
        public DbSet<DeficitMaterials> DeficitMaterials { get; set; }
        public DbSet<DeficitCalcMaterials> DeficitCalcMaterials { get; set; }
        public DbSet<StoreSettings> StoreSettings { get; set; }
        public DbSet<SettingTypes> SettingTypes { get; set; }
        public DbSet<GlobalSettings> GlobalSettings { get; set; }
        public DbSet<Expenditures> Expenditures { get; set; }
        public DbSet<Alarms> Alarms { get; set; }
        public DbSet<DataItems> DataItems { get; set; }
        public DbSet<DataItemsQuery> DataItemsQuery { get; set; }
        public DbSet<PlcTypes> PlcTypes { get; set; }
        public DbSet<UserTasks> UserTasks { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<AccessRights> AccessRights { get; set; }
        public DbSet<StoreTypes> StoreTypes { get; set; }
        public DbSet<DeviceBindings> DeviceBindings { get; set; }
        public DbSet<StorageGroupUsers> StorageGroupUsers { get; set; }
        public DbSet<DeviceBindingSettings> DeviceBindingSettings { get; set; }
        public DbSet<ZoneNamesByStore> ZoneNamesByStore { get; set; }
        public DbSet<WareHousePresences> WareHousePresences { get; set; }
        public DbSet<StoreLoad> StoreLoad { get; set; }
        public DbSet<HistoryKeepings> HistoryKeepings { get; set; }
        public DbSet<ReceiptsForAcceptance> ReceiptsForAcceptance { get; set; }
        public DbSet<CellQuantityByZones> CellQuantityByZones { get; set; }

        static WH_Context()
        {
            Database.SetInitializer<WH_Context>(null);
        }

        public WH_Context(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
