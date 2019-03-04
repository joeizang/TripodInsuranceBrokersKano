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
            //var clients
            return new List<DetailClientApiModel>();
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clients
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
