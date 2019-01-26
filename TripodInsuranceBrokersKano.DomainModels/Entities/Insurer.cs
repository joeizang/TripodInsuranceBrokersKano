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

        public string TelephoneNumber { get; set; }

        public string SecondTelephoneNumber { get; set; }

        public string ThirdNumber { get; set; }

        public string ForthNumber { get; set; }

        public string FifthNumber { get; set; }

        public string ContactPerson { get; set; }


    }
}
