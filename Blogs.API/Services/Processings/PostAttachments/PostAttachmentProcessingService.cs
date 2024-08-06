using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;
using Blogs.API.Services.Foundations.PostAttachments;

namespace Blogs.API.Services.Processings.PostAttachments
{
    public class PostAttachmentProcessingService : IPostAttachmentProcessingService
    {
        private readonly IPostAttachmentService postAttachmentService;

        public PostAttachmentProcessingService(IPostAttachmentService postAttachmentService)
        {
            this.postAttachmentService = postAttachmentService;
        }

        public async ValueTask<PostAttachment> AddPostAttachmentAsync(PostAttachment postAttachment)
        {
            return await this.postAttachmentService.AddPostAttachmentAsync(postAttachment);
        }

        public async ValueTask<PostAttachment> TryRemovePostAttachmentAsync(
            Guid postId, 
            Guid attachmentId)
        {
            PostAttachment maybePostAttachment =
                await this.postAttachmentService.RetrievePostAttachmentByIdAsync(
                    postId, 
                    attachmentId);

            return await this.postAttachmentService.RemovePostAttachmentAsync(maybePostAttachment);
        }
    }
}