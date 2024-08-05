using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Comments;
using Blogs.API.Models.Likes;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Models.Posts
{
    public class Post
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public Author Author { get; set; }
        public string Content { get; set; }
        public PostCategory Category { get; set; }
        public string Tags { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        public IEnumerable<PostAttachment> PostAttachments { get; set; }
    }
}