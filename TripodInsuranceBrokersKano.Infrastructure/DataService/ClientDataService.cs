using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Specifications.ClientSpecs;

namespace TripodInsuranceBrokersKano.Infrastructure.DataService
{
    public class ClientDataService
    {
        private readonly IRepository<Client> _repo;
        private readonly IMapper _mapper;
        private readonly ISpecification<Client> _spec;

        public ClientDataService(IRepository<Client> repo, 
                                 IMapper mapper,ISpecification<Client> spec)
        {
            _repo = repo;
            _mapper = mapper;
            _spec = spec;
        }

        public bool VerifyNoDuplicateClient(CreateClientApiModel model)
        {
            var checks = _repo.Query(_spec.AddPredicates(x => !x.Name.Equals(model.ClientName),
                x => !x.EmailAddress.Equals(model.EmailAddress))).AsNoTracking().ToList();
            if (checks.Count == 0)
                return true;
            // there are duplicates
            return false;
        }


        public void CreateClient(CreateClientApiModel model, string creator)
        {
            var client = _mapper.Map<CreateClientApiModel, Client>(model);
            _repo.Add(client);
        }

        public void UpdateClient(UpdateClientApiModel model, string updator)
        {
            var targetClient = _repo.Get(_spec.AddPredicates(x => x.Id == model.TargetClientId));
            //use automapper to map the apimodel to entity and save it.
            var tclient = _mapper.Map<UpdateClientApiModel, Client>(model, targetClient);
            _repo.Update(tclient);
            
        }

        public DetailClientApiModel DetailClient(int id)
        {
            var targetClient = _repo.Get(_spec.AddPredicates(c => c.Id == id));
            var mClient = _mapper.Map<Client, DetailClientApiModel>(targetClient);
            return mClient;
        }

        public List<DetailClientApiModel> GetAllClients()
        {
            var list = _repo.GetAll(_spec);
            var clientList = _mapper.Map<List<DetailClientApiModel>>(list);
            return clientList;
        }

        public void DeleteClient(DeleteClientApiModel model, string deletor)
        {
            var client = _repo.Get(_spec.AddPredicates(
                    c => c.Id == model.Id &&
                    c.Name.Equals(model.Name, StringComparison.InvariantCultureIgnoreCase)));
            
            _repo.Delete(client);
        }

        public int SaveChanges()
        {
            return _repo.Commit();
        }
    }
}
