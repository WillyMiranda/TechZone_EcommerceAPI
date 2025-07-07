using AutoMapper;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand;

namespace TechZone.Ecommerce.UseCases.Common.Mappings
{
    internal sealed class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
