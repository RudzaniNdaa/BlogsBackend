using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class ForbiddenRepliesException : Xeption
    {
        public ForbiddenRepliesException(Exception innerException)
            : base(message: "Forbidden reply access error occurred, contact support.", innerException)
        { }
    }
}