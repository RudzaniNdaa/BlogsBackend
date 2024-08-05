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
        public DbSet<Comment> Comments { get; set; }

        public async ValueTask<Comment> InsertCommentAsync(Comment comment) =>
            await InsertAsync(comment);

        public IQueryable<Comment> SelectAllComments() =>
            SelectAll<Comment>();

        public async ValueTask<Comment> SelectCommentByIdAsync(Guid commentId) =>
            await SelectAsync<Comment>(commentId);

        public async ValueTask<Comment> UpdateCommentAsync(Comment comment) =>
            await UpdateAsync(comment);

        public async ValueTask<Comment> DeleteCommentAsync(Comment comment) =>
            await DeleteAsync(comment);
    }
}