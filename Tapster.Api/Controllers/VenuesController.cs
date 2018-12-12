using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using Utils.Mapper;
using Tapster.Api.Models.Venues;
using Tapster.Common.Services;
using Tapster.DomainEntities.Entities;

namespace Tapster.Api.Controllers
{
    public class VenuesController : ODataController
    {
        private readonly IMapperService mapper;
        private readonly IVenuesService venuesService;

        public VenuesController(IMapperService mapper, IVenuesService venuesService)
        {
            this.mapper = mapper;
            this.venuesService = venuesService;
        }

        // GET: api/Venues
        [EnableQuery]
        [HttpGet(Name = nameof(GetVenues))]
        public IActionResult GetVenues()
        {
            var venues = venuesService.GetVenues();
            var model = mapper.ProjectTo<Venue, VenueVM>(venues);
            return Ok(model);
        }

        // GET: api/Venues/5
        [EnableQuery]
        [ODataRoute("Venues({id})")]
        [HttpGet("{id}", Name = nameof(GetVenue))]
        public IActionResult GetVenue([FromODataUri] Guid id)
        {
            var venue = venuesService.GetVenue(id);
            if (venue == null) return NotFound();

            var model = mapper.AutoMap<Venue, VenueVM>(venue);

            return Ok(model);
        }
        
        // POST: api/Venues
        [HttpPost]
        public ActionResult CreateVenue([FromBody]CreateVenueVM createModel)
        {
            if (createModel == null) return BadRequest();
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var venue = mapper.AutoMap<CreateVenueVM, Venue>(createModel);

            venuesService.AddVenue(venue);

            var model = mapper.AutoMap<Venue, VenueVM>(venue);

            return CreatedAtAction(nameof(CreateVenue), model);
        }
        
        // PUT: api/Venues/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Venue venue)
        {
            return NoContent();
        }
        
        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
