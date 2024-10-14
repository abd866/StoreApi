using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entities.IdentityEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.TokenServices
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenServices( IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new  SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }
        public string GnerateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.GivenName, appUser.DisplyName),
                new Claim("UserId", appUser.Id),
                new Claim("UserName", appUser.UserName),
            };
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha256);
            var TokenDescripter = new SecurityTokenDescriptor
            { 
                Subject=new ClaimsIdentity(claims),
                Issuer = _configuration["Token:Issuer"],
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };
            var tokenHandeler = new JwtSecurityTokenHandler();
            var token = tokenHandeler.CreateToken(TokenDescripter);
            return tokenHandeler.WriteToken(token);
        }
    }
}
