using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnetforum.BLL.Dtos;
using dotnetforum.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnetforum.Api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet(Name = "GetAccount")]

        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<ApplicationUser>> Get()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterUserDTO registerUserDTO)
        {
            var user = new ApplicationUser
            { UserName = registerUserDTO.UserName, Email = registerUserDTO.Email };
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            /*if (!string.IsNullOrWhiteSpace(registerUserDTO.Level))
                await _userManager.AddClaimAsync(user,
                new Claim(nameof(registerUserDTO.Level), registerUserDTO.Level));*/

            return Ok();
        }

        public async Task<IActionResult> Delete()
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}