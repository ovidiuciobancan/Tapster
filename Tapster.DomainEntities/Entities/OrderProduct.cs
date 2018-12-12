using System;

namespace Tapster.DomainEntities.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public Order Order { get; set; }
        public Product Product  { get; set; }

    }
}
