﻿using System;
using System.Collections.Generic;
using apibackend.Abstractions;

namespace apibackend.Entities
{
    public class CreditNote : BaseEntity
    {
        public ICollection<Insurer> Insurers { get; set; }

        public string CreditNoteNumber { get; set; }

        public Client Insured { get; set; }

        public int InsuredId { get; set; }

        public ICollection<Policy> Policies { get; set; }

        public DateTimeOffset PolicyEffectiveStartDate { get; set; }

        public DateTimeOffset PolicyEffectiveEndDate { get; set; }

        public decimal GrossPremium { get; set; }

        public decimal NetPremium { get; set; }

        public byte[] Signed { get; set; }

    }
}
