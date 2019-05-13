using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetforum.BLL.Services;
using dotnetforum.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetforum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService commentService;

        public CommentController(ICommentService service) : base()
        {
            commentService = service;
        }


        // POST: api/Comment
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Comment>> Post([FromBody] Comment comment)
        {
            var newComment = await commentService.InsertCommentAsync(comment);

            return CreatedAtAction(
                    nameof(ReviewController.Get),
                    new { id = newComment.Id }
                );
        }


        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "OwnerOrAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
