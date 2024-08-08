using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class FailedRepliesStorageException : Xeption
    {
        public FailedRepliesStorageException(Exception innerException)
            : base(message: "Failed replies storage error occurred, contact support.", innerException)
        { }
    }
}