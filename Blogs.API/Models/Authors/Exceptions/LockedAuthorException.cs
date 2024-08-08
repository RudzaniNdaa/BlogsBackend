using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class LockedAuthorException : Xeption
    {
        public LockedAuthorException(Exception innerException)
            : base(message: "Locked author record exception, please try again later", innerException)
        {
        }
    }
}