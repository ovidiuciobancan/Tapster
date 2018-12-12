using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class Waiter
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Venue Venue { get; set; }
        public ICollection<WaiterTable> WaiterTables { get; set; } = new List<WaiterTable>();
    }
}
