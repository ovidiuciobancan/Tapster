using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class Venue
    {
        public Guid Id { get; set; }
        public Guid MangerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public string ImageUrl { get; set; }

        public Manager Manager { get; set; }
        public ICollection<Waiter> Waiters { get; set; } = new List<Waiter>();
        public ICollection<Table> Tables { get; set; } = new List<Table>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
