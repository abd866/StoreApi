using Store.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.UserServices
{
    public interface IUserServices
    {
        Task<UserDto> Login(LoginDto input);
        Task<UserDto> Register(RegisterDto input);
    }
}
