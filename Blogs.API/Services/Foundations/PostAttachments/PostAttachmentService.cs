using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.PostAttachments;

namespace Blogs.API.Services.Foundations.PostAttachments
{
    public class PostAttachmentService : IPostAttachmentService
    {
        private readonly IStorageBroker storageBroker;

        public PostAttachmentService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<PostAttachment> AddPostAttachmentAsync(PostAttachment postAttachment)
        {
            return await this.storageBroker.InsertPostAttachmentAsync(postAttachment);
        }

        public IQueryable<PostAttachment> RetrieveAllPostAttachments()
        {
            return this.storageBroker.SelectAllPostAttachments();
        }

        public async ValueTask<PostAttachment> RetrievePostAttachmentByIdAsync(
            Guid postId, 
            Guid attachmentId)
        {
            return await this.storageBroker.SelectPostAttachmentByIdAsync(postId, attachmentId);
        }

        public async ValueTask<PostAttachment> RemovePostAttachmentAsync(
            PostAttachment postAttachment)
        {
            return await this.storageBroker.DeletePostAttachmentAsync(postAttachment);
        }
    }
}