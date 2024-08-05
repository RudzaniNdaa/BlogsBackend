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
        private static void SetPostAttachmentConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostAttachment>()
                .HasKey(postAttachment =>
                new {postAttachment.PostId, postAttachment.AttachmentId});

            modelBuilder.Entity<PostAttachment>()
                .HasOne(postAttachment => postAttachment.Post)
                .WithMany(post => post.PostAttachments)
                .HasForeignKey(postAttachment => postAttachment.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostAttachment>()
                .HasOne(postAttachment => postAttachment.Attachment)
                .WithMany(attachment => attachment.PostAttachments)
                .HasForeignKey(postAttachment => postAttachment.AttachmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}