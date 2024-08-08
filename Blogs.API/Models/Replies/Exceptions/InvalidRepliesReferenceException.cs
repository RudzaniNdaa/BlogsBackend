using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class InvalidRepliesReferenceException : Xeption
    {
        public InvalidRepliesReferenceException(Exception innerException)
            : base(message: "Invalid reply reference error occurred.", innerException) { }
    }
}