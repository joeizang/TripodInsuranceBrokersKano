using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels
{
    public class DeleteInsurerApiModel : IApiModel
    {
        public int InsurerId { get; set; }
    }
}
