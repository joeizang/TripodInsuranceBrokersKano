using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.InsurerModuleTests
{
    public class InsurerAutoMappingTests
    {
        public MapperConfiguration Config { get; set; }

        public InsurerAutoMappingTests()
        {
            Config = new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(InsurerMapperProfile));
            });
        }

        [Fact]
        public void InsurerMappingValid()
        {
            var mapper = TestStartup.CreateMapper(Config);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
