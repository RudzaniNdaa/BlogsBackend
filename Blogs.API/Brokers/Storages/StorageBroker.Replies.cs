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
        public DbSet<Reply> Replies { get; set; }

        public async ValueTask<Reply> InsertReplyAsync(Reply reply) =>
            await InsertAsync(reply);

        public IQueryable<Reply> SelectAllReplies() =>
            SelectAll<Reply>();

        public async ValueTask<Reply> SelectReplyByIdAsync(Guid replyId) =>
            await SelectAsync<Reply>(replyId);

        public async ValueTask<Reply> UpdateReplyAsync(Reply reply) =>
            await UpdateAsync(reply);

        public async ValueTask<Reply> DeleteReplyAsync(Reply reply) =>
            await DeleteAsync(reply);
    }
}