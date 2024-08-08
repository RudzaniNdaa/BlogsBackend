using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class FailedCommentServiceException : Xeption
    {
        public FailedCommentServiceException(Exception innerException)
            : base(message: "Failed comment service occurred, please contact support", innerException)
        { }
    }
}