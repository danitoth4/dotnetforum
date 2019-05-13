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

        public virtual Creation Creation { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
