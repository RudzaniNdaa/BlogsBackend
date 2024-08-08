using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class FailedRepliesServiceException : Xeption
    {
        public FailedRepliesServiceException(Exception innerException)
            : base(message: "Failed reply service occurred, please contact support", innerException)
        { }
    }
}