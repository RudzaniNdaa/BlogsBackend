using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class FailedLikeStorageException : Xeption
    {
        public FailedLikeStorageException(Exception innerException)
            : base(message: "Failed like storage error occurred, contact support.", innerException)
        { }
    }
}