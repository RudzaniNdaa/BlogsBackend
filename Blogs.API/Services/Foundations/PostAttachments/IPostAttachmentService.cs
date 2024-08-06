using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Services.Foundations.PostAttachments
{
    public interface IPostAttachmentService
    {
        public ValueTask<PostAttachment> AddPostAttachmentAsync(PostAttachment postAttachment);
        public IQueryable<PostAttachment> RetrieveAllPostAttachments();
        public ValueTask<PostAttachment> RetrievePostAttachmentByIdAsync(Guid postId, Guid attachmentId);
        public ValueTask<PostAttachment> RemovePostAttachmentAsync(PostAttachment postAttachment);
    }
}