using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class Manager
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Venue> Venues { get; set; } = new List<Venue>();
    }
}
