using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class CommentServiceException : Xeption
    {
        public CommentServiceException(Exception innerException)
            : base(message: "Comment service error occurred, contact support.", innerException)
        { }
    }
}