using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class FailedAuthorServiceException : Xeption
    {
        public FailedAuthorServiceException(Exception innerException)
            : base(message: "Failed author service occurred, please contact support", innerException)
        { }
    }
}