using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.PolicyApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles
{
    public class PolicyMapperProfile : Profile
    {
        public PolicyMapperProfile()
        {
            CreateMap<Policy, DetailPolicyApiModel>()
                .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType))
                .ForMember(dest => dest.Insured, opt => opt.MapFrom(src => src.Insured.Name))
                .ForMember(dest => dest.Insurers, opt => opt.MapFrom(src => src.Insurers))
                .ReverseMap();
        }
    }
}
