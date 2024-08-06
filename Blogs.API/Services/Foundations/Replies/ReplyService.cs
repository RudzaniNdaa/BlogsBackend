using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Replies;

namespace Blogs.API.Services.Foundations.Replies
{
    public class ReplyService : IReplyService
    {
        private readonly IStorageBroker storageBroker;

        public ReplyService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Reply> AddReplyAsync(Reply reply)
        {
            return await this.storageBroker.InsertReplyAsync(reply);
        }

        public IQueryable<Reply> RetrieveAllReplies()
        {
            return this.storageBroker.SelectAllReplies();
        }

        public async ValueTask<Reply> RetrieveReplyByIdAsync(Guid replyId)
        {
            return await this.storageBroker.SelectReplyByIdAsync(replyId);
        }

        public async ValueTask<Reply> ModifyReplyAsync(Reply reply)
        {
            return await this.storageBroker.UpdateReplyAsync(reply);
        }

        public async ValueTask<Reply> RemoveReplyAsync(Reply reply)
        {
            return await this.storageBroker.DeleteReplyAsync(reply);
        }
    }
}