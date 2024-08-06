using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;
using Blogs.API.Services.Foundations.Comments;

namespace Blogs.API.Services.Processings.Comments
{
    public class CommentProcessingService : ICommentProcessingService
    {
        private readonly ICommentService commentService;

        public CommentProcessingService(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async ValueTask<Comment> UpsertCommentAsync(Comment comment)
        {
            IQueryable<Comment> comments =
                this.commentService.RetrieveAllComments();
            Comment maybeComment =
                comments.FirstOrDefault(retrievedComment => retrievedComment.ID == comment.ID);

            return maybeComment switch
            {
                { } => await this.commentService.ModifyCommentAsync(comment),
                _ => await this.commentService.AddCommentAsync(comment)
            };
        }

        public IQueryable<Comment> RetrieveAllComments()
        {
            return this.commentService.RetrieveAllComments();
        }

        public async ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId)
        {
            return await this.commentService.RetrieveCommentByIdAsync(commentId);
        }

        public async ValueTask<Comment> TryRemoveCommentByIdAsync(Guid commentId)
        {
            Comment maybeComment =
                await this.commentService.RetrieveCommentByIdAsync(commentId);

            return await this.commentService.RemoveCommentAsync(maybeComment);
        }
    }
}