using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Services.Processings.PostAttachments
{
    public interface IPostAttachmentProcessingService
    {
        public ValueTask<PostAttachment> AddPostAttachmentAsync(PostAttachment postAttachment);
        public ValueTask<PostAttachment> TryRemovePostAttachmentAsync(Guid postId, Guid attachmentId);
    }
}