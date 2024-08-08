using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class ForbiddenPostAttachmentException : Xeption
    {
        public ForbiddenPostAttachmentException(Exception innerException)
            : base(message: "Forbidden post attachment access error occurred, contact support.", innerException)
        { }
    }
}