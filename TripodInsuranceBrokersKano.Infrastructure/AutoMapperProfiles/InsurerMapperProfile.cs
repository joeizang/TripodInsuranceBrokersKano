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
            CreateMap<Insurer, IndexInsurerApiModel>();
            CreateMap<CreateInsurerApiModel, Insurer>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy,
                opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy,
                opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.ActionType,
                opt => opt.Ignore())
                .ForMember(dest => dest.Deleted,
                opt => opt.Ignore())
                .ForMember(dest => dest.Id,
                opt => opt.Ignore()).ReverseMap();

            CreateMap<UpdateInsurerApiModel, Insurer>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy,
                opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy,
                opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt,
                opt => opt.Ignore())
                .ForMember(dest => dest.ActionType,
                opt => opt.Ignore())
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Deleted,
                opt => opt.Ignore()).ReverseMap();
        }
    }
}
