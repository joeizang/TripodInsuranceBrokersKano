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
        

        public ClientDataService(IRepository<Client> repo, IMapper mapper):base(repo,mapper)
        {
        }

        
        
    }
}
