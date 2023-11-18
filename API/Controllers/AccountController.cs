using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly TokenServices tokenServices;

        public AccountController(UserManager<AppUser> userManager, TokenServices tokenServices)
        {
            this.userManager = userManager;
            this.tokenServices = tokenServices;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var results = await userManager.CheckPasswordAsync(user, loginDto.Password);

            if (results)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = tokenServices.CreateToken(user),
                    Username = user.UserName
                };
            }

            return Unauthorized();
        }

    }
}