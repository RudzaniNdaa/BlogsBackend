using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetPostConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(post => post.Author)
                .WithMany(author => author.Posts)
                .HasForeignKey(post => post.AuthorID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}