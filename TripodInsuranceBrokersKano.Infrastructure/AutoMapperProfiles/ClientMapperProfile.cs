using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TripodInsuranceBrokersKano.DomainModels.ApiModels.ClientApiModels;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.AutoMapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Client, UpdateClientApiModel>()
                .ForMember(dest => dest.TargetClientId,
                    opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.ContactAddress, opt => 
                    opt.MapFrom(source => source.OtherAddress))
                .ReverseMap();
            //CreateMap<Client, DetailClientApiModel>();
            CreateMap<Client, CreateClientApiModel>()
                .ForMember(dest => dest.ContactAddress,
                    opt => opt.MapFrom(source => source.OtherAddress))
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(source => source.Name))
                .ReverseMap();
        }
    }
}
