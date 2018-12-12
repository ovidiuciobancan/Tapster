using Tapster.Common.Repositories;
using Utils.DataAccess.Interfaces;

namespace Tapster.Common.UnitsOfWork
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IClientsRepository Clients { get; }
        IProductsRepository Products { get; }
        IManagersRepository Managers { get; }
        IVenuesRepository Venues { get; }
        ITablesRepository Tables { get; }
        ICategoriesRepository Categries { get; }
    }
}
