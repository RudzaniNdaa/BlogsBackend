using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class InvalidAuthorReferenceException : Xeption
    {
        public InvalidAuthorReferenceException(Exception innerException)
            : base(message: "Invalid author reference error occurred.", innerException) { }
    }
}