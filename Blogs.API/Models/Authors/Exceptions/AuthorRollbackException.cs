using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AuthorRollbackException : Xeption
    {
        public AuthorRollbackException(Exception innerException)
            : base(message: "Author rollback error occurred, contact support.", innerException)
        { }
    }
}