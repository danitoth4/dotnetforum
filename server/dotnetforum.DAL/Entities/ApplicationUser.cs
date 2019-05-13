using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public class ApplicationUser  : IdentityUser<int>
    {
    
        public virtual ICollection<Review> Reviews { get; } = new List<Review>();

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();


    }
}
