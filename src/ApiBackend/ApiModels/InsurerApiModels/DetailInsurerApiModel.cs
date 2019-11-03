using apibackend.Entities;

namespace apibackend.ApiModels.InsurerApiModels
{
    public class DetailInsurerApiModel
    {
        public string InsurerName { get; set; }

        public Address Address { get; set; }

        public string ContactPerson { get; set; }

        public string EmailAddress { get; set; }
        public PhoneNumbers PhoneNumbers { get; set; }
    }
}
