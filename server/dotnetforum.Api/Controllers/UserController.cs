using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetforum.BLL.Services;
using dotnetforum.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetforum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service) : base()
        {
            userService = service;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get()
        {
            return (await userService.GetUsersAsync()).ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<ApplicationUser>> Get(int id)
        {
            return await userService.GetUserAsync(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Post([FromBody] ApplicationUser user)
        {
            var newUser = await userService.InsertUserAsync(user);

            return CreatedAtAction(
                    nameof(Get),
                    new { id = newUser.Id }
                );
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicationUser user)
        {
            await userService.UpdateUserAsync(id, user);

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
