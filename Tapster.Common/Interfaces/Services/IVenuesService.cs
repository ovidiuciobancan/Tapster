using System;
using System.Collections.Generic;
using Tapster.DomainEntities.Entities;

namespace Tapster.Common.Services
{
    public interface IVenuesService
    {
        void AddVenue(Venue venue);
        void DeleteVenue(Guid id);
        IEnumerable<Table> GetTables(Guid venueId);
        Venue GetVenue(Guid id);
        IEnumerable<Venue> GetVenues();
        void UpdateVenue(Venue venue);

        IEnumerable<Category> GetMenu(Guid venueId);
    }
}