using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Replies;

namespace Blogs.API.Services.Foundations.Replies
{
    public interface IReplyService
    {
        public ValueTask<Reply> AddReplyAsync(Reply reply);
        public IQueryable<Reply> RetrieveAllReplies();
        public ValueTask<Reply> RetrieveReplyByIdAsync(Guid replyId);
        public ValueTask<Reply> ModifyReplyAsync(Reply reply);
        public ValueTask<Reply> RemoveReplyAsync(Reply reply);
    }
}