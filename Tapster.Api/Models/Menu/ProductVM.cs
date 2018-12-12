using System;
using Tapster.DomainEntities.Enums;

namespace Tapster.Api.Models.Products
{
    public class ProductVM
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public CurrencyTypes Currency { get; set; }
    }
}