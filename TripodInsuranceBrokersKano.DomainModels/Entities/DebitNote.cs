﻿using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class DebitNote : BaseEntity
    {
        public string DebitNoteNumber { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public Policy Policy { get; set; }

        public int PolicyId { get; set; }

        public List<Insurer> Insurers { get; set; }

        public decimal Commission { get; set; }

        public byte[] Signature { get; set; }

        public PremiumType PremiumType { get; set; }
    }
}
