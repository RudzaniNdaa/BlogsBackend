using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class PostAttachmentDependencyException : Xeption
    {
        public PostAttachmentDependencyException(Xeption innerException) :
            base(message: "Post attachment dependency error occurred, contact support.", innerException)
        { }
    }
}