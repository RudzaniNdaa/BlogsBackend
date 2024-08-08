using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class NullPostAttachmentException : Xeption
    {
        public NullPostAttachmentException()
            : base(message: "Post attachment is null.")
        { }
    }
}