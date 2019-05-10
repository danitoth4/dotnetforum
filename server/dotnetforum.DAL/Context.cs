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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().HasOne(c => c.User).WithMany(u => u.Comments).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Author = "mr. author",
                        Description = "yo",
                        Title = "ttl",
                        CreatedAt = DateTime.Now
                    }
                );
        }

    }
}
