using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDTO createUserDTO)
        {
            User user = _mapper.Map<User>(createUserDTO);

            IdentityResult result = await _userManager.CreateAsync(user, createUserDTO.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Failed to create user");
        }

        public async Task<string> Login(LoginUserDTO loginUserDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.UserName, loginUserDTO.Password, false, false);  // verifica os dados de login

            if(!result.Succeeded)
            {
                throw new ApplicationException("Unauthenticated user");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedUserName == loginUserDTO.UserName.ToUpper());  // busca o usuário

            var token = _tokenService.GenerateToken(user);  // gera o token

            return token;
        }
    }
}