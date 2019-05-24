using AutoMapper;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Specifications;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.InsurerModuleTests
{
    public class InsurerDataServiceTests
    {

        public Mock<IRepository<Insurer>> Repo { get; set; }

        public IMapper Mapper { get; set; }

        public Mock<ISpecification<Insurer>> Spec { get; set; }


        public InsurerDataServiceTests()
        {
            Repo = new Mock<IRepository<Insurer>>();
            Mapper = TestStartup.CreateMapper();
            Spec = new Mock<ISpecification<Insurer>>();
        }

        [Fact]
        public void CheckForDuplicate_ReturnsTrue()
        {
            var address = new Faker<Address>()
                .RuleFor(x => x.BuildingNumber, v => v.Random.AlphaNumeric(3))
                .RuleFor(x => x.CloseLandMarks, v => v.Lorem.Sentences(1))
                .RuleFor(x => x.StreetName, v => v.Address.StreetName()).Generate();

            var phone = new Faker<PhoneNumbers>()
                .RuleFor(x => x.TelephoneNumber, v => v.Phone.PhoneNumber())
                .RuleFor(x => x.SecondTelephoneNumber, v => v.Phone.PhoneNumber())
                .RuleFor(x => x.ThirdNumber, v => v.Phone.PhoneNumber())
                .RuleFor(x => x.ForthNumber, v => v.Phone.PhoneNumber())
                .RuleFor(x => x.FifthNumber, v => v.Phone.PhoneNumber())
                .Generate();

            var apimodel = new Faker<CreateInsurerApiModel>()
                .RuleFor(x => x.EmailAddress, v => v.Internet.Email())
                .RuleFor(x => x.InsurerName, v => "FBN Insurance")
                .RuleFor(x => x.ContactPerson, v => v.Person.FullName)
                .RuleFor(x => x.Address, address)
                .RuleFor(x => x.PhoneNumbers, phone)                
                .Generate();

            var spec = new Specification<Insurer>();
            spec.Predicates.Add(p => p.InsurerName.Equals("Leadway Insurance"));

            Repo.Setup(x => x.Query(spec)).Returns(new List<Insurer>().AsQueryable());

            var srv = new InsurerDataService(Repo.Object, Mapper);

            var result = srv.CheckForDuplicate(apimodel);

            Assert.True(result);
        }
    }
}
