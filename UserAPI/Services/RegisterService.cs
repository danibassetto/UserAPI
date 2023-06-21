using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public RegisterService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Register(CreateUserDTO createUserDTO)
        {
            User user = _mapper.Map<User>(createUserDTO);

            IdentityResult result = await _userManager.CreateAsync(user, createUserDTO.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Failed to create user");
        }
    }
}