using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class RepliesServiceException : Xeption
    {
        public RepliesServiceException(Exception innerException)
            : base(message: "Reply service error occurred, contact support.", innerException)
        { }
    }
}