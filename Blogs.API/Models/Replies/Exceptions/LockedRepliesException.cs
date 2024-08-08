using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class LockedRepliesException : Xeption
    {
        public LockedRepliesException(Exception innerException)
            : base(message: "Locked reply record exception, please try again later", innerException)
        {
        }
    }
}