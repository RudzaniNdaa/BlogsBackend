using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class ForbiddenPostException : Xeption
    {
        public ForbiddenPostException(Exception innerException)
            : base(message: "Forbidden post access error occurred, contact support.", innerException)
        { }
    }
}