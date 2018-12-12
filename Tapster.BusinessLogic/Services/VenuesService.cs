using System;
using System.Collections.Generic;

using Tapster.Common.Services;
using Tapster.Common.UnitsOfWork;
using Tapster.DomainEntities.Entities;

namespace Tapster.BusinessLogic.Services
{
    public class VenuesService : IVenuesService
    {
        private readonly IAppUnitOfWork uow;

        public VenuesService(IAppUnitOfWork uow)
        {
            this.uow = uow;
        }

        #region Venues
        public IEnumerable<Venue> GetVenues() => uow.Venues.Query;
        public Venue GetVenue(Guid id) => uow.Venues.Get(id);
        public void AddVenue(Venue venue)
        {
            uow.InTransaction(() =>
            {
                uow.Venues.Add(venue);
            });
        }
        public void UpdateVenue(Venue venue)
        {
            uow.InTransaction(() =>
            {
                uow.Venues.Update(venue);
            });
        }
        public void DeleteVenue(Guid id)
        {
            uow.InTransaction(() =>
            {
                uow.Venues.Remove(id);
            });
        }
        #endregion

        #region Menu
        public IEnumerable<Category> GetMenu(Guid venueId)
        {
            return uow.Categries.GetByVenue(venueId);
        }
        #endregion

        public IEnumerable<Table> GetTables(Guid venueId) => uow.Tables.GetByVenue(venueId);
    }
}
