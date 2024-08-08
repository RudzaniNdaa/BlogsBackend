using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class PostAttachmentDependencyValidationException : Xeption
    {
        public PostAttachmentDependencyValidationException(Xeption innerException)
            : base(message: "Post attachment dependency validation occurred, please try again.", innerException)
        { }
    }
}