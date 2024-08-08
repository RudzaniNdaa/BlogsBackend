using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class FailedCommentStorageException : Xeption
    {
        public FailedCommentStorageException(Exception innerException)
            : base(message: "Failed comment storage error occurred, contact support.", innerException)
        { }
    }
}