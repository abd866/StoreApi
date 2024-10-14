using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntity;
using Store.Services.TokenServices;
using Store.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.UserServices
{
    public class UserServices : IUserServices

    {
        private readonly  SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;

        public UserServices(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,ITokenServices tokenServices )
        {
            _signInManager = signInManager;
            _userManager = userManager;
           _tokenServices = tokenServices;
        }
        public async Task<UserDto> Login(LoginDto input)
        {
            var user =await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
                return null;
            var rusult = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            if (!rusult.Succeeded)
                throw new Exception("Login FAILD");
            return new UserDto
            {
                Id=Guid.Parse(user.Id),
                DisplayName=user.DisplyName,
                Email=user.Email,
                Token=_tokenServices.GnerateToken(user)

            };
        }

        public async Task<UserDto> Register(RegisterDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user is not null)
                return null;
            var appUser = new AppUser
            {
                DisplyName = input.DisplayName,
                Email = input.Email,
                UserName = input.DisplayName,
            };
            var rusult =  await _userManager.CreateAsync(appUser,input.Password);
            if (!rusult.Succeeded)
                throw new Exception("Register FAILD");
            return new UserDto
            {
                Id = Guid.Parse(appUser.Id),
                DisplayName = appUser.DisplyName,
                Email = appUser.Email,
                Token = _tokenServices.GnerateToken(appUser)

            };

        }
    }
}
