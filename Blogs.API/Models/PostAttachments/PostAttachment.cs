using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Attachments;
using Blogs.API.Models.Posts;

namespace Blogs.API.Models.PostAttachments
{
    public class PostAttachment
    {
        public Guid PostId { get; set; }
        public Guid AttachmentId { get; set; }

        public Post Post { get; set; }
        public Attachment Attachment { get; set; }
    }
}