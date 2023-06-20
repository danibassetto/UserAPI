using AutoMapper;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateUserDTO, User>();
        }
    }
}
