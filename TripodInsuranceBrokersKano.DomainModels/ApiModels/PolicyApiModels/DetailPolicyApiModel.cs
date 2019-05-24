using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.PolicyTypeApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.ApiModels.PolicyApiModels
{
    public class DetailPolicyApiModel : IApiModel
    {
        public string InsurerPolicyNumber { get; set; }

        public string InternalPolicyNumber { get; set; }

        public DetailPolicyTypeApiModel PolicyType { get; set; }

        public int PolicyTypeId { get; set; }

        public string Description { get; set; }

        public string PolicyTermDocument { get; set; }

        public decimal GrossPolicyValuation { get; set; }

        public decimal NetPolicyValuation { get; set; }

        public bool MultiInsurerPolicy { get; set; }

        public string Insured { get; set; }

        public int IndemnityPeriod { get; set; }

        public int InsuredId { get; set; }

        public DateTimeOffset PolicyEffectiveStartDate { get; set; }

        public DateTimeOffset PolicyEffectiveEndDate { get; set; }

        public ICollection<DetailInsurerApiModel> Insurers { get; set; }
    }
}
