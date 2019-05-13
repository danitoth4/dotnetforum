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
    public class CreationController : ControllerBase
    {
        private readonly ICreationService creationService;

        public CreationController(ICreationService service) : base()
        {
            creationService = service;
        }

        // GET: api/Creation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creation>>> Get()
        {
            return (await creationService.GetCreationsAsync()).ToList();
        }

        // GET: api/Creation/5
        [HttpGet("{id}", Name = "GetCreation")]
        public async Task<ActionResult<Creation>> Get(int id)
        {
            return await creationService.GetCreationAsync(id);
        }

    }
}