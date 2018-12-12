using System;

namespace Tapster.DomainEntities.Entities
{
    public class WaiterTable
    {
        public Guid Id { get; set; }
        public Guid WaiterId { get; set; }
        public Guid TableId { get; set; }

        public Waiter Waiter { get; set; }
        public Table Table { get; set; }
    }
}
