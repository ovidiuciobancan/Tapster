using System;
using Microsoft.AspNet.OData;
using System.Linq;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using Utils.Mapper;
using Tapster.Common.Services;
using Tapster.DomainEntities.Entities;
using Tapster.Api.Models.Categories;

namespace Tapster.Api.Controllers
{
    [Produces("application/json")]
    public class MenuCategoriesController : Controller
    {
        private readonly IMapperService mapper;
        private readonly IVenuesService venuesService;

        public MenuCategoriesController(IMapperService mapper, IVenuesService venuesService)
        {
            this.mapper = mapper;
            this.venuesService = venuesService;
        }

        // GET: api/Venues
        [HttpGet]
        //[Route("venues/{venueId}/menucategories", Name = nameof(GetMenuCategories))]
        public IActionResult GetMenuCategories(Guid venueId)
        {
            var menuCategories = venuesService.GetMenu(venueId);
            var model = mapper.ProjectTo<Category, CategoryVM>(menuCategories).AsQueryable();

            return Ok(model);
        }
    }
}
