using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class PostAttachmentValidationException : Xeption
    {
        public PostAttachmentValidationException(Xeption innerException)
            : base(message: "Post attachment validation errors occurred, please try again.",
                  innerException)
        { }
    }
}