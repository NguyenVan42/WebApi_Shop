using System;

namespace WebApi_Shop.Models
{
    public class CommentModel
    {
        public int Rating { get; set; }

        public string Comments { get; set; }

        public Guid ItemId { get; set; }
    }
}
