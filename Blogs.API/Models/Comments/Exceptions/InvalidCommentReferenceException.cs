using System;
using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class InvalidCommentReferenceException : Xeption
    {
        public InvalidCommentReferenceException(Exception innerException)
            : base(message: "Invalid comment reference error occurred.", innerException) { }
    }
}