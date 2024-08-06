using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;

namespace Blogs.API.Services.Processings.Comments
{
    public interface ICommentProcessingService
    {
        public ValueTask<Comment> UpsertCommentAsync(Comment comment);
        public IQueryable<Comment> RetrieveAllComments();
        public ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId);
        public ValueTask<Comment> TryRemoveCommentByIdAsync(Guid commentId);
    }
}