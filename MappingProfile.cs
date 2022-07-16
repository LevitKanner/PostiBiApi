using Api.Entities.Dtos;
using Api.Entities.Models;
using AutoMapper;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, ApplicationUser>();
    }
}