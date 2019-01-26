using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactPerson { get; set; }

        public Address CompanyAddress { get; set; }

        public Address CorrespondenceAddress { get; set; }

        public bool Insured { get; set; }

        public double? PolicyPercentage { get; set; }

    }
}
