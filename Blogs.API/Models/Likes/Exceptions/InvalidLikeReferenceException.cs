using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class InvalidLikeReferenceException : Xeption
    {
        public InvalidLikeReferenceException(Exception innerException)
            : base(message: "Invalid like reference error occurred.", innerException) { }
    }
}