using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Replies;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<Reply> InsertReplyAsync(Reply reply);
        public IQueryable<Reply> SelectAllReplies();
        public ValueTask<Reply> SelectReplyByIdAsync(Guid replyId);
        public ValueTask<Reply> UpdateReplyAsync(Reply reply);
        public ValueTask<Reply> DeleteReplyAsync(Reply reply);
    }
}