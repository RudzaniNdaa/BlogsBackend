using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class RepliesRollbackException : Xeption
    {
        public RepliesRollbackException(Exception innerException)
            : base(message: "Rwply rollback error occurred, contact support.", innerException)
        { }
    }
}