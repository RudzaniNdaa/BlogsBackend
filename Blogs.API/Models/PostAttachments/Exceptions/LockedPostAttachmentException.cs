using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class LockedPostAttachmentException : Xeption
    {
        public LockedPostAttachmentException(Exception innerException)
            : base(message: "Locked post attachment record exception, please try again later", innerException)
        {
        }
    }
}