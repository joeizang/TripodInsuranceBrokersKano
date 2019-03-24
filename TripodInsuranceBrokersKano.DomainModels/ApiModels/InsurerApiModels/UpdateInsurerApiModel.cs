using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels
{
    public class UpdateInsurerApiModel
    {
        public string InsurerName { get; set; }

        public Address Address { get; set; }

        public string ContactPerson { get; set; }

        public string EmailAddress { get; set; }

        public PhoneNumbers PhoneNumbers { get; set; }

        public int Id { get; set; }
    }
}
