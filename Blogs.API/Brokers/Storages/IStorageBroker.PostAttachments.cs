using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<PostAttachment> InsertPostAttachmentAsync(PostAttachment postAttachment);
        public IQueryable<PostAttachment> SelectAllPostAttachments();
        public ValueTask<PostAttachment> SelectPostAttachmentByIdAsync(Guid postId, Guid attachmentId);
        public ValueTask<PostAttachment> DeletePostAttachmentAsync(PostAttachment postAttachment);
    }
}