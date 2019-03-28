using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Exceptions;

namespace TripodInsuranceBrokersKano.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurersController : ControllerBase
    {
        private readonly InsurerDataService _service;

        public InsurersController(InsurerDataService service)
        {
            _service = service;
        }
        // GET: api/Insurers
        [HttpGet]
        public async Task<ActionResult<List<IndexInsurerApiModel>>> Get()
        {
            var result = await _service.GetAllInsurers(new InsurerInputModel());
            if (!(result is null)) return Ok(result);
            return Ok(new List<IndexInsurerApiModel>());
        }

        // GET: api/Insurers/5
        [HttpGet("{id}")]
        public ActionResult<DetailInsurerApiModel> Get(int id)
        {
            var result = _service.DetailInsurer(id);
            if (!(result is null)) return Ok(result);
            return BadRequest();
        }

        // POST: api/Insurers
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateInsurerApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            try
            {
                await _service.CreateInsurer(model);
                return CreatedAtAction(nameof(Post), model);
            }
            catch (DuplicateRecordException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Insurers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UpdateInsurerApiModel model)
        {
            if (ModelState.IsValid && id != model.Id) return BadRequest();
            try
            {
                _service.UpdateInsurer(model);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = new DeleteInsurerApiModel { InsurerId = id };
            _service.DeleteInsurer(model);
        }
    }
}
