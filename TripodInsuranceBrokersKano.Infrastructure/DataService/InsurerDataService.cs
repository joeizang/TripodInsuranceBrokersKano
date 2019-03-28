using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Exceptions;

namespace TripodInsuranceBrokersKano.Infrastructure.DataService
{
    public class InsurerDataService : DataServiceBase<Insurer>
    {
        public InsurerDataService(IRepository<Insurer> repo, IMapper mapper, ISpecification<Insurer> spec) 
            : base(repo, mapper, spec)
        {
        }


        public async Task<bool> CheckForDuplicate(CreateInsurerApiModel model)
        {
            var result = await _repo.Query(_spec.AddPredicates<Insurer>(x => x.InsurerName.Equals(model.InsurerName)))
                .AsNoTracking().ToListAsync();
            if (result.Count > 0)
                return true;
            return false;
        }


        public async Task CreateInsurer(CreateInsurerApiModel model)
        {
            if(await CheckForDuplicate(model))
            {
                var insurer = _mapper.Map<CreateInsurerApiModel, Insurer>(model);
                _repo.Add(insurer);
                _repo.Commit();
            }

            throw new DuplicateRecordException("Looks like this insurer already exists!!");
        }


        public void UpdateInsurer(UpdateInsurerApiModel model)
        {
            var insurer = _repo.Get(_spec.AddPredicates<Insurer>(i => i.Id == model.Id));

            if (insurer is null)
                throw new NotFoundException("The Insurer you are looking for doesn't exist!");
            var updated = _mapper.Map<UpdateInsurerApiModel, Insurer>(model, insurer);
            _repo.Update(updated);
            _repo.Commit();
        }


        public void DeleteInsurer(DeleteInsurerApiModel model)
        {
            var insurer = _repo.Get(_spec.AddPredicates<Insurer>(i => i.Id == model.InsurerId));
            _repo.Delete(insurer);
            _repo.Commit();
        }


        public async Task<List<IndexInsurerApiModel>> GetAllInsurers(InsurerInputModel model)
        {
            if (model.CurrentPage == 0) model.CurrentPage = 1;
            if (model.PageSize == 0) model.PageSize = 15;
            var result = await _repo.Query(_spec).AsNoTracking()
                              .Skip((model.CurrentPage - 1) * model.PageSize)
                              .Take(model.PageSize)
                              .ToListAsync();
            var results = _mapper.Map<List<IndexInsurerApiModel>>(result);
            return results;
        }

        public DetailInsurerApiModel DetailInsurer(int id)
        {
            var target = _repo.Get(_spec.AddPredicates(i => i.Id == id));
            var insurer = _mapper.Map<Insurer, DetailInsurerApiModel>(target);
            return insurer;
        }

        public void DeleteInsurer(int id)
        {
            var target = _repo.Get(_spec.AddPredicates(i => i.Id == id));
            _repo.Delete(target);
            _repo.Commit();
        }
    }
}
