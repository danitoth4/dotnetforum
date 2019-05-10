using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime WritenAt { get; set; }

        public int CreationId { get; set; }

        public Creation Creation { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
