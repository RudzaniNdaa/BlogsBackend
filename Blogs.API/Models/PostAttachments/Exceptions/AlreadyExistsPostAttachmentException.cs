using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class AlreadyExistsPostAttachmentException : Xeption
    {
        public AlreadyExistsPostAttachmentException(Exception innerException)
            : base(message: "Post attachment with the same Id already exists.", innerException)
        { }
    }
}