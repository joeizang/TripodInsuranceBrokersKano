﻿using System;
using System.Collections.Generic;
using apibackend.ApiModels.ClientApiModels;
using apibackend.ApiModels.InsurerApiModels;

namespace apibackend.ApiModels.PolicyApiModels
{
    public class CreatePolicyApiModel
    {
        public string InsurerPolicyNumber { get; set; }

        public string InternalPolicyNumber { get; set; }

        public DetailPolicyApiModel PolicyType { get; set; }

        public int PolicyTypeId { get; set; }

        public string Description { get; set; }

        public string PolicyTermDocument { get; set; }

        public decimal GrossPolicyValuation { get; set; }

        public decimal NetPolicyValuation { get; set; }

        public bool MultiInsurerPolicy { get; set; }

        public DetailClientApiModel Insured { get; set; }

        public int IndemnityPeriod { get; set; }

        public int InsuredId { get; set; }

        public DateTimeOffset PolicyEffectiveStartDate { get; set; }

        public DateTimeOffset PolicyEffectiveEndDate { get; set; }

        public ICollection<DetailInsurerApiModel> Insurers { get; set; }
    }
}
