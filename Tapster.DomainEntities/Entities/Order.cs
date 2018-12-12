using System;
using System.Collections.Generic;
using Tapster.DomainEntities.Enums;

namespace Tapster.DomainEntities.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ClientSessionId { get; set; }
        public OrderStatusTypes Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public TimeSpan? ETA { get; set; }

        public ClientSession ClientSession { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
