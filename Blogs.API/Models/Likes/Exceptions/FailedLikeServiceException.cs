using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class FailedLikeServiceException : Xeption
    {
        public FailedLikeServiceException(Exception innerException)
            : base(message: "Failed like service occurred, please contact support", innerException)
        { }
    }
}