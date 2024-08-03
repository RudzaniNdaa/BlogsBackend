using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Replies
{
    public class Reply
    {
        public Guid ID { get; set; }
        public Guid CommentID { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}