using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Models.Attachments
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public byte[] Contents { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public string ExternalUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<PostAttachment> PostAttachments { get; set; }
    }
}