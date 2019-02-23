using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.PolicyModuleTests
{
    public class PolicyAutoMappingTests
    {
        public MapperConfiguration Config { get; set; }

        public PolicyAutoMappingTests()
        {
            Config = new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(PolicyMapperProfile));
            });
        }

        [Fact]
        public void PolicyMappingValid()
        {
            var mapper = TestStartup.CreateMapper(Config);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
