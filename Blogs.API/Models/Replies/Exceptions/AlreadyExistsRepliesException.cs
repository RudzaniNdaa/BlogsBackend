using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class AlreadyExistsRepliesException : Xeption
    {
        public AlreadyExistsRepliesException(Exception innerException)
            : base(message: "Reply with the same Id already exists.", innerException)
        { }
    }
}