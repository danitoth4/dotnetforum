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
    public class ReviewService : IReviewService
    {
        private readonly Context context;

        public ReviewService(Context context)
        {
            this.context = context;
        }

        public async Task<Review> GetReviewAsync(int reviewId)
        {
            return await context.Reviews
                .Include(r => r.Comments)
                .Include(r => r.User)
                .Include(r => r.Creation)
                    .SingleOrDefaultAsync(r => r.Id == reviewId) ?? throw new EntityNotFoundException("The review could not be found");
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            var reviews = await context.Reviews
                .Include(r => r.Comments)
                .Include(r => r.User)
                .Include(r => r.Creation)
                    .ToListAsync();

            return reviews;
        }

        public async Task<Review> InsertReviewAsync(Review newReview)
        {
            context.Reviews.Add(newReview);

            await context.SaveChangesAsync();

            return newReview;
        }

        public async Task UpdateReviewAsync(int reviewId, Review updatedReview)
        {
            updatedReview.Id = reviewId;
            var entry = context.Attach(updatedReview);
            entry.State = EntityState.Modified;
            await  context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            context.Reviews.Remove(new Review { Id = reviewId });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new EntityNotFoundException("The review could not be found");
            }
        }
    }
}
