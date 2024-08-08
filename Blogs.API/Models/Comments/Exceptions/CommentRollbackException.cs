using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class CommentRollbackException : Xeption
    {
        public CommentRollbackException(Exception innerException)
            : base(message: "Comment rollback error occurred, contact support.", innerException)
        { }
    }
}