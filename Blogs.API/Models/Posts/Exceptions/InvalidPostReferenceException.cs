using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class InvalidPostReferenceException : Xeption
    {
        public InvalidPostReferenceException(Exception innerException)
            : base(message: "Invalid post reference error occurred.", innerException) { }
    }
}