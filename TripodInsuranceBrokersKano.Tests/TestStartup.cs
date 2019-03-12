using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.Tests
{
    public class TestStartup
    {
        private TestStartup()
        {

        }

        internal static IMapper Mapper { get; private set; }

        public static IMapper CreateMapper(params IConfigurationProvider[] provider)
        {
            foreach(var p in provider)
            {
                if(Mapper is null)
                {
                    Mapper = new Mapper(p);
                    return Mapper;
                }
                //It means the Mapper has already been created.
                //replace existing provider with new one
                Mapper.GetType().GetProperty(nameof(Mapper.ConfigurationProvider))
                    .SetValue(Mapper.ConfigurationProvider, p);
            }
            return Mapper;
        }
    }
}
