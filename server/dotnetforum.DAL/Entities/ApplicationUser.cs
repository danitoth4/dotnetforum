using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public class ApplicationUser  : IdentityUser<int>
    {
    
        public ICollection<Review> Reviews { get; } = new List<Review>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();


    }
}
