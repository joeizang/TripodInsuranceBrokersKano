﻿using apibackend.Entities;

namespace apibackend.ApiModels.ClientApiModels
{
    public class UpdateClientApiModel
    {
        public string Name { get; set; }

        public Address ClientAddress { get; set; }

        public Address ContactAddress { get; set; }

        public string ContactPerson { get; set; }

        public string Description { get; set; }

        public string EmailAddress { get; set; }

        public int TargetClientId { get; set; }

        public bool Insured { get; set; }

        public double? PolicyPercentage { get; set; }


    }
}
