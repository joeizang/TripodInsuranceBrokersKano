using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.DataService
{
    public class PolicyDataService : DataServiceBase<Policy>
    {


        public PolicyDataService(IRepository<Policy> repo, IMapper mapper): base(repo, mapper)
        {

        }
    }
}
