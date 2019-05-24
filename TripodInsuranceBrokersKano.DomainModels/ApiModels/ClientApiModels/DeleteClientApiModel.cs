using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels
{
    public class DeleteClientApiModel : IApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
