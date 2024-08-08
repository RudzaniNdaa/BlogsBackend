using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class ForbiddenAuthorException : Xeption
    {
        public ForbiddenAuthorException(Exception innerException)
            : base(message: "Forbidden author access error occurred, contact support.", innerException)
        { }
    }
}