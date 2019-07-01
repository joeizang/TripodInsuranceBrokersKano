using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels
{
    public class CreateClientApiModel : IApiModel //structure of names should be verb->entityname->apimodel
    {
        public string ClientName { get; set; }

        public Address ClientAddress { get; set; }

        public Address ContactAddress { get; set; }

        public string ContactPerson { get; set; }

        public string Description { get; set; }

        public string EmailAddress { get; set; }

        public bool Insured { get; set; }


    }
}
