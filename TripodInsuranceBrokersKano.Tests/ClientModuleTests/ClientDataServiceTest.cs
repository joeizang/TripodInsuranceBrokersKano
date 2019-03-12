using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Http;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using TripodInsuranceBrokersKano.Infrastructure.Context;
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


        public ClientDataServiceTest()
        {
            Config = new MapperConfiguration(options =>
            {
                options.AddProfile(typeof(ClientMapperProfile));
            });
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
            var client = new Faker<Client>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Id, 1)
                .RuleFor(c => c.ContactPerson, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentences())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.ClientAddress, f => new Address())
                .RuleFor(c => c.OtherAddress, f => new Address()).Generate();

            var spec = new Mock<ISpecification<Client>>();
            spec.Setup(c => c.Predicates)
                .Returns(new List<Expression<Func<Client, bool>>>() { x => x.Id == 1 });

            var http = new Mock<IHttpContextAccessor>();
            http.Setup(x => x.HttpContext.User.Identity.Name).Returns("loggedinuser@app.com");


            var repo = new Mock<IRepository<Client>>();

            var cspec = new ClientSpec();

            var mapper = TestStartup.CreateMapper(Config);

            repo.Setup(x => x.Add(client))
                .Verifiable();
            var datasrv = new ClientDataService(repo.Object, mapper, cspec);

            datasrv.CreateClient(apimodel, http.Object.HttpContext.User.Identity.Name);

            
        }
    }
}
