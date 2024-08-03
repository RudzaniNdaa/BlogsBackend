using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;

namespace Blogs.API.Models.Posts
{
    public class Post
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public string Content { get; set; }
        public PostCategory Category { get; set; }
        public string Tags { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}