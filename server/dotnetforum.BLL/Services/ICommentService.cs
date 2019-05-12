using dotnetforum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public interface ICommentService
    {
        Task<Comment> GetCommentAsync(int commentId);

        //Task<IEnumerable<Comment>> GetCommentsAsync();

        Task<Comment> InsertCommentAsync(Comment newComment);

        //Task UpdateCommentAsync(int commentId, Comment updatedComment);

        Task DeleteCommentAsync(int commentId);
    }
}
