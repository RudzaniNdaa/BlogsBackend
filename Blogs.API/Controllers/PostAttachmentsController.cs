using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;
using Blogs.API.Services.Processings.PostAttachments;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Blogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostAttachmentsController : RESTFulController
    {
        private readonly IPostAttachmentProcessingService postAttachmentProcessingService;

        public PostAttachmentsController(IPostAttachmentProcessingService postAttachmentProcessingService)
        {
            this.postAttachmentProcessingService = postAttachmentProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<PostAttachment>> PostPostAttachmentAsync(
            PostAttachment postAttachment)
        {
            PostAttachment addPostAttachment =
                await this.postAttachmentProcessingService.AddPostAttachmentAsync(postAttachment);

            return Ok(addPostAttachment);
        }

        [HttpDelete("posts/{postId}/attachments/{attachmentId}")]
        public async ValueTask<ActionResult<PostAttachment>> DeletePostAttachmentByIdAsync(
            Guid postId,
            Guid attachmentId)
        {
            PostAttachment deletePostAttachment =
                await this.postAttachmentProcessingService.TryRemovePostAttachmentAsync(
                    postId,
                    attachmentId);

            return Ok(deletePostAttachment);
        }
    }
}