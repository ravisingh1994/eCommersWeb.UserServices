﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponce>()
        .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
        .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
        .ForMember(dest => dest.Sucess, opt => opt.Ignore())
        .ForMember(dest => dest.Token, opt => opt.Ignore());

        // Create Mapper for Register
        CreateMap<RegisterRequest, ApplicationUser>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
        .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)); 

    }
}

