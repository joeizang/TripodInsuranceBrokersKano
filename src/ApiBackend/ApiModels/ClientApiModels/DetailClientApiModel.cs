using System.Collections.Generic;
using apibackend.ApiModels.PolicyApiModels;
using apibackend.Entities;

namespace apibackend.ApiModels.ClientApiModels
{
    public class DetailClientApiModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactPerson { get; set; }

        public Address ClientAddress { get; set; }

        public Address OtherAddress { get; set; }

        public string EmailAddress { get; set; }

        public bool Insured { get; set; }

        public double? PolicyPercentage { get; set; }

        public List<DetailPolicyApiModel> Policies { get; set; }
    }
}
