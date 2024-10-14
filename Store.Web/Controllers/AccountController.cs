using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.IdentityEntity;
using Store.Services.HandlleResponse;
using Store.Services.UserServices;
using Store.Services.UserServices.Dtos;

namespace Store.Web.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly IUserServices _userServices;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserServices userServices,UserManager<AppUser> userManager)
        {
            _userServices = userServices;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto Input)
        {
            var user = await _userServices.Login(Input);
            if (user == null)
                return BadRequest(new CustomExpetions(400, "Email dose not Exsit",null));
            return Ok(user);

        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto Input)
        {
            var user = await _userServices.Register(Input);
            if (user == null)
                return BadRequest(new CustomExpetions(400, "Email Already Exsit", null));
            return Ok(user);

        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> CetCurentUser()
        {
            var userId = User?.FindFirst("UserId") ;
           var user= await _userManager.FindByIdAsync(userId.Value) ;
            return new UserDto
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.DisplyName,
                Email = user.Email,

            };

        }
    }
}
