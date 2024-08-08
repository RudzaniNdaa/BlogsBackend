using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class PostDependencyValidationException : Xeption
    {
        public PostDependencyValidationException(Xeption innerException)
            : base(message: "Post dependency validation occurred, please try again.", innerException)
        { }
    }
}