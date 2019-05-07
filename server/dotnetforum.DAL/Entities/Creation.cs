using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public abstract class Creation
    {
        public int Id { get; set; }

        public string  Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }

        public ICollection<Review> Reviews { get; } = new List<Review>();

    }
}
