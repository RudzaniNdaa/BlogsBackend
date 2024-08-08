using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class FailedAuthorStorageException : Xeption
    {
        public FailedAuthorStorageException(Exception innerException)
            : base(message: "Failed author storage error occurred, contact support.", innerException)
        { }
    }
}