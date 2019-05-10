﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnetforum.BLL.Dtos;
using dotnetforum.DAL.Entities;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterUserDTO registerUserDTO)
        {
            var user = new ApplicationUser
            { UserName = registerUserDTO.UserName, Email = registerUserDTO.Email };
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if (!string.IsNullOrWhiteSpace(registerUserDTO.Level))
                await _userManager.AddClaimAsync(user,
                new Claim(nameof(registerUserDTO.Level), registerUserDTO.Level));
            return Ok();
        }
    }
}