using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Comment> Comments { get; set; }


    }
}
