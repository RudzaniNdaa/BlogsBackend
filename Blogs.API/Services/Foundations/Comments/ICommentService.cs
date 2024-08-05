using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;

namespace Blogs.API.Services.Foundations.Comments
{
    public interface ICommentService
    {
        public ValueTask<Comment> AddCommentAsync(Comment comment);
        public IQueryable<Comment> RetrieveAllComments();
        public ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId);
        public ValueTask<Comment> ModifyCommentAsync(Comment comment);
        public ValueTask<Comment> RemoveCommentAsync(Comment comment);
    }
}