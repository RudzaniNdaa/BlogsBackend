using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class StudentRollbackException : Xeption
    {
        public StudentRollbackException(Exception innerException)
            : base(message: "Post attachment rollback error occurred, contact support.", innerException)
        { }
    }
}