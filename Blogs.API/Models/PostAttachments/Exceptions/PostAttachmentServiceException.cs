using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class PostAttachmentServiceException : Xeption
    {
        public PostAttachmentServiceException(Exception innerException)
            : base(message: "Post attachment service error occurred, contact support.", innerException)
        { }
    }
}