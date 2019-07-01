using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Exceptions;
using TripodInsuranceBrokersKano.Infrastructure.Specifications;

namespace TripodInsuranceBrokersKano.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurersController : ControllerBase
    {
        private readonly InsurerDataService _service;
        private readonly ISpecification<Insurer> _spec;

        public InsurersController(InsurerDataService service, ISpecification<Insurer> spec)
        {
            _service = service;
            _spec = spec;
        }
        // GET: api/Insurers
        [HttpGet]
        public async Task<ActionResult<List<IndexInsurerApiModel>>> Get()
        {
            var result = await _service.GetAllInsurers(new InsurerInputModel(),new Specification<Insurer>());
            if (!(result is null)) return Ok(result);
            return Ok(new List<IndexInsurerApiModel>());
        }

        // GET: api/Insurers/5
        [HttpGet("{id}")]
        public ActionResult<DetailInsurerApiModel> Get(int id)
        {
            _spec.AddPredicates(x => x.Id == id);
            var result = _service.GetById<DetailInsurerApiModel>(id, _spec);
            if (!(result is null)) return Ok(result);
            return BadRequest();
        }

        // POST: api/Insurers
        [HttpPost]
        public ActionResult Post([FromBody] CreateInsurerApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            try
            {
                _service.Create(model,HttpContext?.User?.Identity?.Name);
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
                _spec.AddPredicates(x => x.Id == model.Id);
                _service.Update(model,_spec);
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
            _service.Delete(model, _spec);
        }
    }
}
