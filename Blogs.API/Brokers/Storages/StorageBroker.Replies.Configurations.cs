using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Replies;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetReplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>()
                .HasOne(reply => reply.Comment)
                .WithMany(comment => comment.Replies)
                .HasForeignKey(reply => reply.CommentID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}