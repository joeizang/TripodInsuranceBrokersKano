using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
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


        public void CreateClient(CreateClientApiModel model, string creator)
        {
            var client = _mapper.Map<CreateClientApiModel, Client>(model);

            client.GetType().GetProperty(nameof(client.CreatedAt))
                .SetValue(client,DateTimeOffset.UtcNow);
            client.GetType().GetProperty(nameof(client.CreatedBy))
                .SetValue(client, creator);
        }

        public void UpdateClient(UpdateClientApiModel model, string updator)
        {
            var targetClient = _repo.Get(_clientSpec
                .AddPredicate(x => x.Id == model.TargetClientId));
            //use automapper to map the apimodel to entity and save it.
            var tclient = _mapper.Map<UpdateClientApiModel, Client>(model);
            tclient.GetType().GetProperty(nameof(tclient.UpdatedAt))
                .SetValue(tclient, DateTimeOffset.UtcNow);
            tclient.GetType().GetProperty(nameof(tclient.UpdatedBy))
                .SetValue(tclient, updator);
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
            client.GetType().GetProperty("UpdatedAt")
                    .SetValue(client.UpdatedAt, DateTimeOffset.UtcNow);
            _repo.Delete(client);
        }

        public int SaveChanges()
        {
            return _repo.Commit();
        }
    }
}
