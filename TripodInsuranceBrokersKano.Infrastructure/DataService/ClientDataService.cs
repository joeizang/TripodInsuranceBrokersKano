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
        private ClientSpec _clientSpec;
        private readonly IMapper _mapper;


        public ClientDataService(IRepository<Client> repo, 
                                 IMapper mapper,
                                 ClientSpec clientSpec)
        {
            _repo = repo;
            _clientSpec = clientSpec;
            _mapper = mapper;
        }

        public bool VerifyNoDuplicateClient(CreateClientApiModel model)
        {
            var checks = _repo.Query(_clientSpec.AddPredicate(x => !x.Name.Equals(model.ClientName),
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
            var targetClient = _repo.Get(_clientSpec
                .AddPredicate(x => x.Id == model.TargetClientId));
            //use automapper to map the apimodel to entity and save it.
            var tclient = _mapper.Map<UpdateClientApiModel, Client>(model, targetClient);
            _repo.Update(tclient);
            
        }

        public DetailClientApiModel DetailClient(int id)
        {
            var targetClient = _repo.Get(_clientSpec
                .AddPredicate(c => c.Id == id));
            var mClient = _mapper.Map<Client, DetailClientApiModel>(targetClient);
            return mClient;
        }

        public List<DetailClientApiModel> GetAllClients()
        {
            var list = _repo.GetAll(_clientSpec);
            var clientList = _mapper.Map<List<DetailClientApiModel>>(list);
            return clientList;
        }

        public void DeleteClient(DeleteClientApiModel model, string deletor)
        {
            var client = _repo.Get(_clientSpec.AddPredicate(
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
