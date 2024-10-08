using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class FailedPostStorageException : Xeption
    {
        public FailedPostStorageException(Exception innerException)
            : base(message: "Failed post storage error occurred, contact support.", innerException)
        { }
    }
}