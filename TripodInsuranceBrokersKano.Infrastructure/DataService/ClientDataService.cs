using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.DataService
{
    public class ClientDataService
    {
        private readonly IRepository<Client> _repo;
        private ISpecification<Client> _clientSpec;


        public ClientDataService(IRepository<Client> repo, ISpecification<Client> clientSpec)
        {
            _repo = repo;
            _clientSpec = clientSpec;
        }


        public void CreateClient(CreateClientApiModel model)
        {
            var client = new Client
            {
                Name = model.ClientName,
                EmailAddress = model.EmailAddress,
                ClientAddress = model.ClientAddress,
                ContactPerson = model.ContactPerson,
                OtherAddress = model.ContactAddress,
                Description = model.Description,
                Insured = false
            };

            client.GetType().GetProperty(nameof(client.CreatedAt))
                .SetValue(client,DateTimeOffset.UtcNow);
        }

        public void UpdateClient(UpdateClientApiModel model)
        {
            var targetClient = _repo.Get(_clientSpec);
            
        }
    }
}
