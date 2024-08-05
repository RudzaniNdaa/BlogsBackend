using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetAuthorComfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasOne(author => author.User)
                .WithMany(user => user.Authors)
                .HasForeignKey(author => author.UserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}