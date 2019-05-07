using dotnetforum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public interface IReviewService
    {
        Task<Review> GetReviewAsync(int reviewId);

        Task<IEnumerable<Review>> GetReviewsAsync();

        Task<Review> InsertReviewAsync(Review newReview);

        Task UpdateReviewAsync(int reviewId, Review updatedReview);

        Task DeleteReviewAsync(int reviewId);
    }
}
