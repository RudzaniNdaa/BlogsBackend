using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AuthorServiceException : Xeption
    {
        public AuthorServiceException(Exception innerException)
            : base(message: "Author service error occurred, contact support.", innerException)
        { }
    }
}