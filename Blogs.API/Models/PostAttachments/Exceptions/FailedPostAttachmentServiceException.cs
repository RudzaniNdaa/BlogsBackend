using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class FailedPostAttachmentServiceException : Xeption
    {
        public FailedPostAttachmentServiceException(Exception innerException)
            : base(message: "Failed post attachment service occurred, please contact support", innerException)
        { }
    }
}