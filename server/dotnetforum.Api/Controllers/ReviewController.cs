﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetforum.BLL.Services;
using dotnetforum.DAL.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetforum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService service) : base()
        {
            reviewService = service;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        {
            return (await reviewService.GetReviewsAsync()).ToList();
        }

        // GET: api/Review/5
        [HttpGet("{id}", Name = "GetReview")]
        public async Task<ActionResult<Review>> Get(int id)
        {
            return await reviewService.GetReviewAsync(id);
        }

        // POST: api/Review
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Review>> Post([FromBody] Review review)
        {
            var newReview = await reviewService.InsertReviewAsync(review);

            return CreatedAtAction(
                    nameof(Get),
                    new { id = newReview.Id }
                );
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes ="Bearer", Policy = "OwnerOrAdmin")]
        public async Task<IActionResult> Put(int id, [FromBody] Review review)
        {
            await reviewService.UpdateReviewAsync(id, review);

            return NoContent();
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "OwnerOrAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
