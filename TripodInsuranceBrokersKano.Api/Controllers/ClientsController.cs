using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Specifications;

namespace TripodInsuranceBrokersKano.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly ClientDataService _service;

        public ClientsController(ClientDataService service)
        {
            _service = service;
        }
        // GET: api/Clients
        [HttpGet]
        public ActionResult<List<DetailClientApiModel>> Get()
        {
            //make sure that any user that get here is logged in os we know what they is upto.
            //TODO: Handle filtering from clients. Make it generic so you write the code one.
            //var clients Handle pagination
            return Ok(_service.GetAll<DetailClientApiModel>(new Specification<Client>()));
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<DetailClientApiModel> Get(int id)
        {
            if(id != 0)
                return _service.GetById<DetailClientApiModel>(id,new Specification<Client>());

            return NotFound();
        }

        // POST: api/Clients
        [HttpPost]
        
        public ActionResult Post([FromBody] CreateClientApiModel model)
        {
            if(ModelState.IsValid && _service.CheckForDuplicate(model))
            {
                _service.Create(model, HttpContext.User?.Identity?.Name);
                return CreatedAtAction(nameof(Get), model);
            }

            return BadRequest(model);
        }

        // PUT: api/Clients/5
        [HttpPut("{model}")]
        public ActionResult Put(int id, [FromBody] UpdateClientApiModel model)
        {
            if(ModelState.IsValid)
            {
                _service.Update(model, new Specification<Client>());
                return NoContent();
            }
            return BadRequest(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = new DeleteClientApiModel { Id = id };
            _service.Delete(model, new Specification<Client>());
            return NoContent();
        }
    }
}
