using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Exceptions;

namespace TripodInsuranceBrokersKano.Infrastructure.DataService
{
    public class ClientDataService : DataServiceBase<Client>
    {
        

        public ClientDataService(IRepository<Client> repo, 
                                 IMapper mapper,ISpecification<Client> spec):base(repo,mapper,spec)
        {
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
            if(VerifyNoDuplicateClient(model))
            {
                var client = _mapper.Map<CreateClientApiModel, Client>(model);
                _repo.Add(client);
                _repo.Commit();
            }
            //a record already exists like this one being created. Send them back
            throw new
                DuplicateRecordException("The record already exists! Are you sure you don't want to update rather than create?");
        }

        public void UpdateClient(UpdateClientApiModel model, string updator)
        {
            var targetClient = _repo.Get(_spec.AddPredicates(x => x.Id == model.TargetClientId));
            //use automapper to map the apimodel to entity and save it.
            var tclient = _mapper.Map<UpdateClientApiModel, Client>(model, targetClient);
            _repo.Update(tclient);
            _repo.Commit();

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
            _repo.Commit();
        }

        
    }
}
