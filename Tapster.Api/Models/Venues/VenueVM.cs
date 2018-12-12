using System;
using System.Collections.Generic;
using Tapster.Api.Models.Categories;

namespace Tapster.Api.Models.Venues
{
    public class VenueVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<CategoryVM> MenuCategories { get; set; } = new List<CategoryVM>();
    }
}
