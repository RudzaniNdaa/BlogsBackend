using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class InvalidPostAttachmentReferenceException : Xeption
    {
        public InvalidPostAttachmentReferenceException(Exception innerException)
            : base(message: "Invalid post attachment reference error occurred.", innerException) { }
    }
}