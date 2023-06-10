using System;

namespace WebApi_Shop.Data
{
    public class Comment
    {
        public Guid Id { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public Guid ItemId { get; set; }

    }
}
