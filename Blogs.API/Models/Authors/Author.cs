using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;
using Blogs.API.Models.Likes;
using Blogs.API.Models.Posts;
using Blogs.API.Models.Users;

namespace Blogs.API.Models.Authors
{
    public class Author
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Like> Likes { get; set; }
    }
}