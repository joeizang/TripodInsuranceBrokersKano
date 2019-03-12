using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.InsurerApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles
{
    public class InsurerMapperProfile : Profile
    {
        public InsurerMapperProfile()
        {
            CreateMap<Insurer, DetailInsurerApiModel>().ReverseMap();
        }
    }
}
