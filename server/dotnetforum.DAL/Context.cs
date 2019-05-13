using dotnetforum.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL
{
    public class Context : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Creation> Creations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().HasOne(c => c.User).WithMany(u => u.Comments).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Creation>().HasDiscriminator<string>("creation_type").HasValue<Book>("type_book").HasValue<Movie>("type_movie");

            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Author = "mr. author",
                        Description = "yo",
                        Title = "ttl",
                        CreatedAt = DateTime.Now.AddMonths(-3)
                    },
                    new Movie
                    {
                        Id = 2,
                        Director = "Mr. Directior",
                        Description = "this is a good movie",
                        Title = "Movie title",
                        CreatedAt = DateTime.Now.AddYears(-1)
                    }
                );

            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        CreationId = 1,
                        Content = "this is a review bout a book",
                        Id = 1,
                        Rating = 4,
                        WritenAt = DateTime.Now.AddDays(-20),
                        UserId = 1                     
                    },
                    new Review
                    {
                        CreationId = 2,
                        Content = "this is a review bout a movie",
                        Id = 2,
                        Rating = 2,
                        WritenAt = DateTime.Now.AddDays(-3),
                        UserId = 2
                    }
                );

            modelBuilder.Entity<Comment>().HasData(
                    new Comment
                    {
                        Content = "yo mate good review you did there i agree",
                        ReviewId = 1,
                        UserId = 2,
                        Id = 1,
                        WritenAt = DateTime.Now.AddDays(-4)
                    },
                    new Comment
                    {
                        Content = "thanks",
                        ReviewId = 1,
                        UserId = 1,
                        Id = 2,
                        WritenAt = DateTime.Now.AddDays(-2)
                    },
                    new Comment
                    {
                        Content = "yo mate bad review you did there i disagree",
                        ReviewId = 2,
                        UserId = 1,
                        Id = 3,
                        WritenAt = DateTime.Now.AddDays(-1)
                    }
                );
        }

    }
}
