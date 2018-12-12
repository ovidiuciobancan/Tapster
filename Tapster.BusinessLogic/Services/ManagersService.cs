using System;
using System.Collections.Generic;

using Tapster.Common.Services;
using Tapster.Common.UnitsOfWork;
using Tapster.DomainEntities.Entities;

namespace Tapster.BusinessLogic.Services
{
    public class ManagersService : IManagersService
    {
        private readonly IAppUnitOfWork uow;

        public ManagersService(IAppUnitOfWork uow) 
        {
            this.uow = uow;
        }

        public IEnumerable<Manager> GetManagers() => uow.Managers.Query;
        public Manager GetManager(Guid id) => uow.Managers.Get(id);
        public void AddManager(Manager manager)
        {
            uow.InTransaction(() =>
            {
                uow.Managers.Add(manager);
            });
        }
        public void UpdateManager(Manager manager)
        {
            uow.InTransaction(() =>
            {
                uow.Managers.Update(manager);
            });
        }
        public void RemoveManager(Guid id)
        {
            uow.InTransaction(() => uow.Managers.Remove(id));
        }
    }
}
