using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.PostAttachments;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<PostAttachment> PostAttachments { get; set; }

        public async ValueTask<PostAttachment> InsertPostAttachmentAsync(
            PostAttachment postAttachment) => 
            await InsertAsync(postAttachment);

        public IQueryable<PostAttachment> SelectAllPostAttachments() =>
            SelectAll<PostAttachment>();

        public async ValueTask<PostAttachment> SelectPostAttachmentByIdAsync(
            Guid postId, 
            Guid attachmentId) =>
            await SelectAsync<PostAttachment>(postId, attachmentId);

        public async ValueTask<PostAttachment> DeletePostAttachmentAsync(
            PostAttachment postAttachment) =>
            await DeleteAsync(postAttachment);
    }
}