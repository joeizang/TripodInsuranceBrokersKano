using System.Collections.Generic;
using apibackend.Abstractions;

namespace apibackend.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactPerson { get; set; }

        public Address ClientAddress { get; set; }

        public Address OtherAddress { get; set; }

        public string EmailAddress { get; set; }

        public bool Insured { get; set; }

        public double? PolicyPercentage { get; set; }

        public List<Policy> Policies { get; set; }

    }
}
