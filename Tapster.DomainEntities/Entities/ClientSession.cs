using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class ClientSession
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid ClientId { get; set; }

        public Session Session { get; set; }
        public Client Client { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
