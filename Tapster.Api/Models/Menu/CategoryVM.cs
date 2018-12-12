using System;
using System.Collections.Generic;
using Tapster.Api.Models.Products;

namespace Tapster.Api.Models.Categories
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<CategoryVM> SubCategories { get; set; } = new List<CategoryVM>();
        public IEnumerable<ProductVM> Products { get; set; } = new List<ProductVM>();
    }
}
