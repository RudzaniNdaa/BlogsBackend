using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LikeServiceException : Xeption
    {
        public LikeServiceException(Exception innerException)
            : base(message: "Like service error occurred, contact support.", innerException)
        { }
    }
}