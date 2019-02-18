using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles;
using Xunit;

namespace TripodInsuranceBrokersKano.Tests.ClientModuleTests
{
    public class ClientAutoMappingTests
    {


        [Fact]
        public void ClientMappingValid()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(typeof(ClientMapperProfile));
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
