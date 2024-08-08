using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AlreadyExistsAuthorException : Xeption
    {
        public AlreadyExistsAuthorException(Exception innerException)
            : base(message: "Author with the same Id already exists.", innerException)
        { }
    }
}