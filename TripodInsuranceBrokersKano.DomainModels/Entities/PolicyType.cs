using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.DomainModels.Entities
{
    public class PolicyType : BaseEntity
    {
        public string Name { get; set; }

        public double Commission { get; set; }


    }
}