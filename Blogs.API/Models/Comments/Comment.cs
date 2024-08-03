using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Comments
{
    public class Comment
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public Guid PostID { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}