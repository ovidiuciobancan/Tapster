using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using Utils.Mapper;
using Tapster.Common.Services;
using Tapster.Api.Models.Managers;
using Tapster.BusinessLogic.Services;
using Tapster.DomainEntities.Entities;

namespace Tapster.Api.Controllers
{
    [Produces("application/json")]
    public class ManagersController : ODataController
    {
        private readonly IMapperService mapper;
        private readonly IManagersService managersService;

        public ManagersController(IMapperService mapper, IManagersService managersService)
        {
            this.mapper = mapper;
            this.managersService = managersService;
        }

        [EnableQuery]
        [HttpGet(Name = nameof(GetManagers))]
        public IActionResult GetManagers()
        {
            var managers = managersService.GetManagers();

            return Ok(mapper.ProjectTo<Manager, ManagerVM>(managers));
        }

        [EnableQuery]
        [HttpGet("{id}", Name = nameof(GetManager))]
        [ODataRoute("Managers({id})")]
        public IActionResult GetManager(Guid id)
        {
            var manager = managersService.GetManager(id);
            if (manager == null) return NotFound();

            return Ok( manager);
        }
        
        // POST: api/Venues
        [HttpPost(Name = nameof(CreateManager))]
        public ActionResult CreateManager([FromBody]Manager manager)
        {
            if (manager == null) return BadRequest();
            if (!ModelState.IsValid) return UnprocessableEntity();

            managersService.AddManager(manager);

            return CreatedAtAction(nameof(CreateManager), manager);
        }
        
        // PUT: api/Venues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        
        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var manager = managersService.GetManager(id);
            if (manager == null) return NotFound();

            managersService.RemoveManager(id);

            return NoContent();
        }
    }
}
