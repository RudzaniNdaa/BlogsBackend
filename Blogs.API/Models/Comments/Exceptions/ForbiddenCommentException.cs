using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class ForbiddenCommentException : Xeption
    {
        public ForbiddenCommentException(Exception innerException)
            : base(message: "Forbidden comment access error occurred, contact support.", innerException)
        { }
    }
}