using Api.Entities.Dtos;
using Api.Entities.Models;
using AutoMapper;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, ApplicationUser>();
        CreateMap<CreatePostDto, Post>();
        CreateMap<Post, PostDto>().ForMember(post => post.CreatedAt,
            expression => expression.MapFrom(post => $"{post.CreatedAt:F}"));
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<UpdatePostDto, Post>();
    }
}