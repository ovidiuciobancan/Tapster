using System;
using System.Collections.Generic;
using System.Text;

namespace Tapster.DomainEntities.Entities
{
    public class Table
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public Venue Venue { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<WaiterTable> WaiterTables { get; set; } = new List<WaiterTable>();
    }
}
