using dotnetforum.BLL.Exceptions;
using dotnetforum.DAL;
using dotnetforum.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly Context context;

        public CommentService(Context context)
        {
            this.context = context;
        }


        public async Task<Comment> InsertCommentAsync(Comment newComment)
        {
            context.Comments.Add(newComment);

            await context.SaveChangesAsync();

            return newComment;
        }

        public async Task DeleteCommentAsync(int CommentId)
        {
            context.Comments.Remove(new Comment { Id = CommentId });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new EntityNotFoundException("The Comment could not be found");
            }
        }
    }
}
