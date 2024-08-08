using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class NotFoundCommentException : Xeption
    {
        public NotFoundCommentException(Guid commentId)
            : base(message: $"Couldn't find comment with commentId: {commentId}.")
        { }
    }
}