using AutoMapper;
using SpendWise.API.DTOs;
using SpendWise.API.Models;

namespace SpendWise.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<User, UserResponseDto>().ReverseMap(); ;
        }
    }
}
