using Ninject.Modules;

using TVM_WMS.SERVER.Services;
using TVM_WMS.SERVER.Interfaces;
using TVM_WMS.SERVER.Repositories;

namespace TVM_WMS.SERVER.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
            //Bind<IUsersService>().To<UsersService>().WithConstructorArgument(connectionString);
            //Bind<IWareHousesService>().To<WareHousesService>().WithConstructorArgument(connectionString);
            //Bind<IMaterialsService>().To<MaterialsService>().WithConstructorArgument(connectionString);
            //Bind<IMaterialGroupsService>().To<MaterialGroupsService>().WithConstructorArgument(connectionString);
            //Bind<IStoreNamesService>().To<StoreNamesService>().WithConstructorArgument(connectionString);
            //Bind<IMeasuresService>().To<MeasuresService>().WithConstructorArgument(connectionString);
           // Bind<IUnitsService>().To<UnitsService>().WithConstructorArgument(connectionString);
           // Bind<IContractorsService>().To<ContractorsService>().WithConstructorArgument(connectionString);
           // Bind<IPackingTypesService>().To<PackingTypesService>().WithConstructorArgument(connectionString);
          //  Bind<ICellZonesService>().To<CellZonesService>().WithConstructorArgument(connectionString);
           // Bind<IReceiptsService>().To<ReceiptsService>().WithConstructorArgument(connectionString);
          //  Bind<IOrdersService>().To<OrdersService>().WithConstructorArgument(connectionString);
            //Bind<IKeepingsService>().To<KeepingsService>().WithConstructorArgument(connectionString);
            //Bind<ICurrencyService>().To<CurrencyService>().WithConstructorArgument(connectionString);
            //Bind<IEnumerationTypesService>().To<EnumerationTypesService>().WithConstructorArgument(connectionString);
            //Bind<IStorageGroupsService>().To<StorageGroupsService>().WithConstructorArgument(connectionString);
            //Bind<IZoneNamesService>().To<ZoneNamesService>().WithConstructorArgument(connectionString);
            //Bind<IStorageGroupZonesService>().To<StorageGroupZonesService>().WithConstructorArgument(connectionString);
            //Bind<IReportsService>().To<ReportsService>().WithConstructorArgument(connectionString);
            //Bind<IRequirementsService>().To<RequirementsService>().WithConstructorArgument(connectionString);
            //Bind<IPersonsService>().To<PersonsService>().WithConstructorArgument(connectionString);
            //Bind<IReceiptAcceptancesService>().To<ReceiptAcceptancesService>().WithConstructorArgument(connectionString);
            //Bind<IDeficitMaterialsService>().To<DeficitMaterialsService>().WithConstructorArgument(connectionString);
            Bind<ISettingsService>().To<SettingsService>().WithConstructorArgument(connectionString);
            //Bind<IExpendituresService>().To<ExpendituresService>().WithConstructorArgument(connectionString);
            //Bind<IProfessionService>().To<ProfessionService>().WithConstructorArgument(connectionString);
        }
    }
}
