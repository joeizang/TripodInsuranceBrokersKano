using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class Receipt : BaseEntity
    {
        public Client Payer { get; set; }

        public decimal Amount { get; set; }

        public Policy Policy { get; set; }

        public int ClientId { get; set; }

        public int PolicyId { get; set; }

        public PaymentType PaymentType { get; set; }

        public string ChequeOrDraftNumber { get; set; }

    }
}
