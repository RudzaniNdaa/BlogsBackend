using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class ForbiddenLikeException : Xeption
    {
        public ForbiddenLikeException(Exception innerException)
            : base(message: "Forbidden like access error occurred, contact support.", innerException)
        { }
    }
}