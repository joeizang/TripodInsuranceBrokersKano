using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.Infrastructure.DataService;

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
            return Ok(_service.GetAllClients());
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<DetailClientApiModel> Get(int? id)
        {
            if(!(id is null))
                return _service.DetailClient(id.Value);

            return NotFound();
        }

        // POST: api/Clients
        [HttpPost]
        
        public ActionResult Post([FromBody] CreateClientApiModel model)
        {
            if(ModelState.IsValid && _service.VerifyNoDuplicateClient(model))
            {
                _service.CreateClient(model, HttpContext.User?.Identity?.Name);
                _service.SaveChanges();
                return Ok();
            }

            return BadRequest(model);
        }

        // PUT: api/Clients/5
        [HttpPut("{model}")]
        public ActionResult Put(int id, [FromBody] UpdateClientApiModel model)
        {
            if(ModelState.IsValid)
            {
                _service.UpdateClient(model, HttpContext.User?.Identity?.Name);
                _service.SaveChanges();
                return Ok();
            }
            return BadRequest(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(DeleteClientApiModel model)
        {
            _service.DeleteClient(model, HttpContext.User?.Identity?.Name);
            _service.SaveChanges();
        }
    }
}
