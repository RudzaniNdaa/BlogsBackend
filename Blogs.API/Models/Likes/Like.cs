using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Posts;

namespace Blogs.API.Models.Likes
{
    public class Like
    {
        public Guid AuthorID { get; set; }
        public Guid PostID { get; set; }
        public int LikeCount { get; set; }

        public Author Author { get; set; }
        public Post Post { get; set; }
    }
}