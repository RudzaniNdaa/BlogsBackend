using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LikeRollbackException : Xeption
    {
        public LikeRollbackException(Exception innerException)
            : base(message: "Like rollback error occurred, contact support.", innerException)
        { }
    }
}