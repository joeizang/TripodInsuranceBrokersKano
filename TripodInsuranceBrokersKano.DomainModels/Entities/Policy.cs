using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class Policy : BaseEntity
    {
        public string InsurerPolicyNumber { get; set; }

        public string InternalPolicyNumber { get; set; }

        public PolicyType PolicyType { get; set; }

        public int PolicyTypeId { get; set; }

        public string Description { get; set; }

        public string PolicyTermDocument { get; set; }

        public decimal GrossPolicyValuation { get; set; }

        public decimal NetPolicyValuation { get; set; }

        public bool MultiInsurerPolicy { get; set; }

        public Client Insured { get; set; }

        public int IndemnityPeriod { get; set; }

        public int InsuredId { get; set; }

        public DateTimeOffset PolicyEffectiveStartDate { get; set; }

        public DateTimeOffset PolicyEffectiveEndDate { get; set; }

        public ICollection<Insurer> Insurers { get; set; }



    }
}
