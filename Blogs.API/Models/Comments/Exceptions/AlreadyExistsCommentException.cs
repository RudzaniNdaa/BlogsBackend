using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class AlreadyExistsCommentException : Xeption
    {
        public AlreadyExistsCommentException(Exception innerException)
            : base(message: "Comment with the same Id already exists.", innerException)
        { }
    }
}