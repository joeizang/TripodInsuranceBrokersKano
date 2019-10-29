using apibackend.Abstractions;

namespace apibackend.Entities
{
    public class PolicyType : BaseEntity
    {
        public string Name { get; set; }

        public double Commission { get; set; }

    }
}