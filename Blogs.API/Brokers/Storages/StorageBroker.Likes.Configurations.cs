using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetLikeConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(like => 
                    new {like.AuthorID, like.PostID});

            modelBuilder.Entity<Like>()
                .HasOne(like => like.Author)
                .WithMany(author => author.Likes)
                .HasForeignKey(like => like.AuthorID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(like => like.Post)
                .WithMany(post => post.Likes)
                .HasForeignKey(like => like.PostID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}