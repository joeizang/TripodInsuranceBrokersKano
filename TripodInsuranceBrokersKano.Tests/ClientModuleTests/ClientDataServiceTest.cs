using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Services;
using TripodInsuranceBrokersKano.Infrastructure.Specifications.ClientSpecs;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.ClientModuleTests
{
    public class ClientDataServiceTest
    {
        public MapperConfiguration Config { get; set; }

        public UserResolverService UserResolver { get; set; }

        public Mock<IRepository<Client>> Repo { get; set; }

        public IMapper Mapper { get; set; }

        public ClientSpec Cspec { get; set; }


        public ClientDataServiceTest()
        {
            Config = new MapperConfiguration(options =>
            {
                options.AddProfile(typeof(ClientMapperProfile));
            });

            Repo = new Mock<IRepository<Client>>();
            Cspec = new ClientSpec();
        }

        [Fact]
        public void CreateClientTest()
        {
            var apimodel = new Faker<CreateClientApiModel>()
                .RuleFor(c => c.ClientName, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.ContactAddress, f => new Address()).Generate();

            var http = new Mock<IHttpContextAccessor>();
            http.Setup(x => x.HttpContext.User.Identity.Name).Returns("loggedinuser@app.com");

            Repo.Setup(x => x.Add(It.IsAny<Client>()))
                .Verifiable();

            Mapper = TestStartup.CreateMapper(Config);

            var datasrv = new ClientDataService(Repo.Object, Mapper, Cspec);

            datasrv.CreateClient(apimodel, http.Object.HttpContext.User.Identity.Name);

            Repo.VerifyAll();
        }


        [Fact]
        public void UpdateClientTest()
        {
            var apimodel = new Faker<UpdateClientApiModel>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.ContactAddress, f => new Address()).Generate();

            var http = new Mock<IHttpContextAccessor>();
            http.Setup(x => x.HttpContext.User.Identity.Name).Returns("loggedinuser@app.com");

            Repo.Setup(x => x.Update(It.IsAny<Client>()))
                .Verifiable();

            Mapper = TestStartup.CreateMapper(Config);

            var datasrv = new ClientDataService(Repo.Object, Mapper, Cspec);

            datasrv.UpdateClient(apimodel, http.Object.HttpContext.User.Identity.Name);

            Repo.VerifyAll();
        }

        [Fact]
        public void DetailClientTest_ReturnsAClient()
        {

            var apimodel = new Faker<DetailClientApiModel>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.OtherAddress, f => new Address()).Generate();

            var mapper = new Mock<IMapper>();

            mapper.Setup(x => x
            .Map<Client, DetailClientApiModel>(
                It.IsAny<Client>()))
            .Returns(apimodel);

            Repo.Setup(x => x.Get(Cspec)).Returns(It.IsAny<Client>());

            Mapper = TestStartup.CreateMapper(Config);

            var service = new ClientDataService(Repo.Object, mapper.Object, Cspec);

            var result = service.DetailClient(1);

            Assert.IsType<DetailClientApiModel>(result);
        }

        [Fact]
        public void GetAllClients_ReturnsListOfClients()
        {

            var apimodel = new Faker<DetailClientApiModel>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.OtherAddress, f => new Address()).Generate(3);

            var clients = new Faker<Client>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.OtherAddress, f => new Address()).Generate(3);

            var mapper = new Mock<IMapper>();

            mapper.Setup(x => x
            .Map<List<DetailClientApiModel>>(It.IsAny<List<Client>>()))
            .Returns(It.IsAny<List<DetailClientApiModel>>);

            Repo.Setup(x => x.GetAll(Cspec)).Returns(It.IsAny<List<Client>>);

            var service = new ClientDataService(Repo.Object, mapper.Object, Cspec);

            var result = service.GetAllClients();

            Assert.IsType<DetailClientApiModel>(result);
        }
    }
}
