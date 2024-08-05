using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Comments;

namespace Blogs.API.Services.Foundations.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IStorageBroker storageBroker;

        public CommentService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Comment> AddCommentAsync(Comment comment)
        {
            return await this.storageBroker.InsertCommentAsync(comment);
        }

        public IQueryable<Comment> RetrieveAllComments()
        {
            return this.storageBroker.SelectAllComments();
        }

        public async ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId)
        {
            return await this.storageBroker.SelectCommentByIdAsync(commentId);
        }

        public async ValueTask<Comment> ModifyCommentAsync(Comment comment)
        {
            return await this.storageBroker.UpdateCommentAsync(comment);
        }

        public async ValueTask<Comment> RemoveCommentAsync(Comment comment)
        {
            return await this.storageBroker.DeleteCommentAsync(comment);
        }
    }
}