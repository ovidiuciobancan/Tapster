using System;
using System.Collections.Generic;
using Tapster.DomainEntities.Enums;

namespace Tapster.DomainEntities.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public CurrencyTypes Currency { get; set; }

        public Category Category { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
