using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class Insurer : BaseEntity
    {
        public string InsurerName { get; set; }

        public Address Address { get; set; }

        public string ContactPerson { get; set; }

        public string EmailAddress { get; set; }
        public PhoneNumbers PhoneNumbers { get; set; }
    }
}
