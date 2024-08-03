using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Likes
{
    public class Like
    {
        public Guid AuthorID { get; set; }
        public Guid PostID { get; set; }
        public int LikeCount { get; set; }
    }
}