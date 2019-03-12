using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.PolicyTypeApiModels
{
    public class CreatePolicyTypeApiModel
    {
        public string Name { get; set; }

        public double Commission { get; set; }
    }
}
