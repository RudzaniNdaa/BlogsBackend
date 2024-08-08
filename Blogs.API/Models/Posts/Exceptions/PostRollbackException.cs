using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class PostRollbackException : Xeption
    {
        public PostRollbackException(Exception innerException)
            : base(message: "Post rollback error occurred, contact support.", innerException)
        { }
    }
}