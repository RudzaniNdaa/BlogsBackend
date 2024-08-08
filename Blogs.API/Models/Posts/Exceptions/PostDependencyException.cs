using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class PostDependencyException : Xeption
    {
        public PostDependencyException(Xeption innerException) :
            base(message: "Post dependency error occurred, contact support.", innerException)
        { }
    }
}