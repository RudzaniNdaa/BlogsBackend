using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class FailedPostAttachmentStorageException : Xeption
    {
        public FailedPostAttachmentStorageException(Exception innerException)
            : base(message: "Failed post attachment storage error occurred, contact support.", innerException)
        { }
    }
}