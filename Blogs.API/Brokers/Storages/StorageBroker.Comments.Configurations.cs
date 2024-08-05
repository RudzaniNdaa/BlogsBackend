using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetCommentConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Author)
                .WithMany(author => author.Comments)
                .HasForeignKey(comment => comment.AuthorID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Post)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.PostID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}