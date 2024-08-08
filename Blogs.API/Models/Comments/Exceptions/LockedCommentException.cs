using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class LockedCommentException : Xeption
    {
        public LockedCommentException(Exception innerException)
            : base(message: "Locked comment record exception, please try again later", innerException)
        {
        }
    }
}