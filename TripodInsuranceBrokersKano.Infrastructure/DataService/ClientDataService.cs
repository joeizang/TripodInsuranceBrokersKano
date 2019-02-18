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


        public void CreateClient(CreateClientApiModel model)
        {
            var client = _mapper.Map<CreateClientApiModel, Client>(model);

            client.GetType().GetProperty(nameof(client.CreatedAt))
                .SetValue(client,DateTimeOffset.UtcNow);
        }

        public void UpdateClient(UpdateClientApiModel model)
        {
            var targetClient = _repo.Get(_clientSpec
                .AddPredicate(x => x.Id == model.TargetClientId));
            //use automapper to map the apimodel to entity and save it.
        }
    }
}
