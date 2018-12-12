using Utils.DataAccess;
using Tapster.Common.UnitsOfWork;
using Tapster.Common.Repositories;
using Tapster.DataAccess.Repositories;

namespace Tapster.DataAccess.UnitsOfWork
{
    public class AppUnitOfWork : EfCoreUnitOfWork, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext context) 
            : base(context)
        {
        }

        private IClientsRepository clients;
        public IClientsRepository Clients => clients ?? (clients = new ClientsRepository(context));

        private IProductsRepository products;
        public IProductsRepository Products => products ?? (products = new ProductsRepository(context));

        private ICategoriesRepository categries;
        public ICategoriesRepository Categries => categries ?? (categries = new CategoriesRepository(context));

        private IManagersRepository managers;
        public IManagersRepository Managers => managers ?? (managers = new ManagersRepository(context));

        private IVenuesRepository venues;
        public IVenuesRepository Venues => venues ?? (venues = new VenuesRepository(context));

        private ITablesRepository tables;
        public ITablesRepository Tables => tables ?? (tables = new TablesRepository(context));

    }
}
