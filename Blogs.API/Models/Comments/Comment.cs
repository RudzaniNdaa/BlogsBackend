using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Posts;
using Blogs.API.Models.Replies;

namespace Blogs.API.Models.Comments
{
    public class Comment
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public Author Author { get; set; }
        public Guid PostID { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<Reply> Replies { get; set; }
    }
}