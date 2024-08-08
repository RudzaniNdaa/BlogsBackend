using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class InvalidPostAttachmentException : Xeption
    {
        public InvalidPostAttachmentException()
            : base(message: "Invalid post attachment. Please correct the errors and try again.")
        { }
    }
}