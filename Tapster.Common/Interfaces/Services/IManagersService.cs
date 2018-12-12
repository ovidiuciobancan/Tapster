using System;
using System.Collections.Generic;
using Tapster.DomainEntities.Entities;

namespace Tapster.Common.Services
{
    public interface IManagersService
    {
        void AddManager(Manager manager);
        Manager GetManager(Guid id);
        IEnumerable<Manager> GetManagers();
        void RemoveManager(Guid id);
        void UpdateManager(Manager manager);
    }
}