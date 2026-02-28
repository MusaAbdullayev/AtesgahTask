using AutoMapper;
using Ecommerse.BL.DTO.User;
using Ecommerse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserGetDTO>();
            CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false));
        }
    }
}
