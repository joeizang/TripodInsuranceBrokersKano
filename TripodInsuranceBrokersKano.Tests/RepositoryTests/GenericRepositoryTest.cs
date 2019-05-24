using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Context;
using TripodInsuranceBrokersKano.Infrastructure.Repository;
using TripodInsuranceBrokersKano.Infrastructure.Services;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.RepositoryTests
{
    public class GenericRepositoryTest
    {

        public DbContextOptions Options { get; set; }

        public GenericRepositoryTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            Options = new DbContextOptionsBuilder<TripodContext>()
                .UseSqlite(connection)
                .Options;
        }

        [Fact]
        public void RepositoryAdd_AddsEntityToDb()
        {
            using (var context = new TripodContext(Options))
            {
                context.Database.EnsureCreated();

                var http = new Mock<IHttpContextAccessor>();
                http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
                var userService = new UserResolverService(http.Object);
                var repo = new GenericRepository<Client>(context, userService);
                var client = new Client
                {
                    ClientAddress = new Address(),
                    ContactPerson = "Some Contact",
                    Description = "Some Description",
                    Name = "A Client",
                    Insured = false,
                    OtherAddress = new Address(),
                    Policies = new List<Policy>(),
                    EmailAddress = "some@emailaddress.com"
                };
                repo.Add(client);

                int result = repo.Commit();

                Assert.True(result != 0);
            }
        }

        [Fact]
        public async Task RepositoryUpdate_IncrementsEntityBeingTrackedByChangeTracker()
        {

            var insurerSeamSpec = new InsurerSeamSpec();
            insurerSeamSpec.Predicates.Add(i => i.InsurerName.Equals("aiico plc"));

            using (var context = new TripodContext(Options))
            {
                context.Database.EnsureCreated();
                await ScaffoldEFTestStructure(context);

                using (var context1 = new TripodContext(Options))
                {
                    var http = new Mock<IHttpContextAccessor>();
                    http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
                    var userService = new UserResolverService(http.Object);
                    var repo1 = new GenericRepository<Insurer>(context1, userService);
                    Insurer insurer = repo1.Get(insurerSeamSpec);

                    insurer.EmailAddress = "manager@aiicoplc.com";
                    repo1.Update(insurer);

                    var result = context1.ChangeTracker.Entries().Count();

                    Assert.Equal(1, result);
                }
                
            }
        }

        [Fact]
        public async Task RepositoryGetAll_ReturnsListOfEntities()
        {
            var insurerSeamSpec = new InsurerSeamSpec();
            insurerSeamSpec.Predicates.Add(x => x.InsurerName.Length != 0);

            using (var context = new TripodContext(Options))
            {
                context.Database.EnsureCreated();
                await ScaffoldEFTestStructure(context);

                using (var context1 = new TripodContext(Options))
                {
                    var http = new Mock<IHttpContextAccessor>();
                    http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
                    var userService = new UserResolverService(http.Object);
                    var repo1 = new GenericRepository<Insurer>(context1, userService);

                    var result = await repo1.Query(insurerSeamSpec).ToListAsync();

                    Assert.Equal(2, result.Count);
                }

            }
        }

        [Fact]
        public async Task RepositoryGet_ReturnsSingleEntity()
        {
            var seam = new InsurerSeamSpec();
            seam.Predicates.Add(i => i.EmailAddress.Equals("manager@insurer.info"));

            using (var context = new TripodContext(Options))
            {
                context.Database.EnsureCreated();
                await ScaffoldEFTestStructure(context);

                using (var context1 = new TripodContext(Options))
                {
                    var http = new Mock<IHttpContextAccessor>();
                    http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
                    var userService = new UserResolverService(http.Object);
                    var repo = new GenericRepository<Insurer>(context1,userService);

                    var result = repo.Get(seam);
                    Assert.IsType<Insurer>(result);
                    Assert.Equal("manager@insurer.info", result.EmailAddress);
                }
            }
        }

        [Fact]
        public async Task RepositoryQuery_ReturnsIQueryable()
        {
            using (var context = new TripodContext(Options))
            {
                context.Database.EnsureCreated();
                await ScaffoldEFTestStructure(context);

                using (var context1 = new TripodContext(Options))
                {
                    var http = new Mock<IHttpContextAccessor>();
                    http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
                    var userService = new UserResolverService(http.Object);
                    var repo = new GenericRepository<Insurer>(context1, userService);

                    var predicates = new List<Expression<Func<Insurer, bool>>>
                    {
                        x => x.InsurerName.Equals("aiico plc")
                    }.ToArray();
                    var includes = new List<Expression<Func<Insurer, object>>>().ToArray();


                    var result = repo.Query(predicates, includes);

                    Assert.IsAssignableFrom<IQueryable<Insurer>>(result);
                }
            }
        }


        private static async Task ScaffoldEFTestStructure(TripodContext context)
        {
            var http = new Mock<IHttpContextAccessor>();
            http.Setup(h => h.HttpContext.User.Identity.Name).Returns("SomeUser@user.com");
            var userService = new UserResolverService(http.Object);
            var repo = new GenericRepository<Insurer>(context, userService);
            var insurers = new List<Insurer>
                {
                    new Insurer
                    {
                        Address = new Address(),
                        ContactPerson = "Branch Manager",
                        EmailAddress = "manager@insurer.info",
                        InsurerName = "aiico plc",
                        PhoneNumbers = new PhoneNumbers()
                    },
                    new Insurer
                    {
                        Address = new Address(),
                        ContactPerson = "Branch Manager",
                        EmailAddress = "manager@leadway.com",
                        InsurerName = "Leadway Insurance plc",
                        PhoneNumbers = new PhoneNumbers()
                    }
                };
            context.Insurers.AddRange(insurers);
            await context.SaveChangesAsync();
        }
    }

    public class InsurerSeamSpec : ISpecification<Insurer>
    {

        public InsurerSeamSpec()
        {
            Predicates = new List<Expression<Func<Insurer, bool>>>();
            Includes = new List<Expression<Func<Insurer, object>>>();
            SortOrder = new List<Expression<Func<Insurer, object>>>();
        }


        public List<Expression<Func<Insurer, bool>>> Predicates { get; set; }
        public List<Expression<Func<Insurer, object>>> SortOrder { get; set; }
        public List<Expression<Func<Insurer, object>>> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
