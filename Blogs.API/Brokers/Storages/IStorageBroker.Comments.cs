using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<Comment> InsertCommentAsync(Comment comment);
        public IQueryable<Comment> SelectAllComments();
        public ValueTask<Comment> SelectCommentByIdAsync(Guid commentId);
        public ValueTask<Comment> UpdateCommentAsync(Comment comment);
        public ValueTask<Comment> DeleteCommentAsync(Comment comment);
    }
}