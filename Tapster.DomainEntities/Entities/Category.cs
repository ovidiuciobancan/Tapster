using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Guid VenueId { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }

        public Venue Venue { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
