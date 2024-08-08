using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LikeDependencyException : Xeption
    {
        public LikeDependencyException(Xeption innerException) :
            base(message: "Like dependency error occurred, contact support.", innerException)
        { }
    }
}