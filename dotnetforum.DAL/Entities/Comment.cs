using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetforum.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ReviewId { get; set; }

        public Review Review { get; set; }

        public DateTime WritenAt { get; }

        public User User { get; set; }

        public int? UserId { get; set; }
    }
}
