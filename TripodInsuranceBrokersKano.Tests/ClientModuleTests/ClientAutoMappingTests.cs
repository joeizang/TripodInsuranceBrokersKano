using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.ClientModuleTests
{
    public class ClientAutoMappingTests
    {
        public MapperConfiguration Config { get; set; }




        public ClientAutoMappingTests()
        {
            Config = new MapperConfiguration(options =>
            {
                options.AddProfile(typeof(ClientMapperProfile));
            });
        }

        [Fact]
        public void ClientMappingValid()
        {
            var mapper = TestStartup.CreateMapper(Config);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        
    }
}
