using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LikeDependencyValidationException : Xeption
    {
        public LikeDependencyValidationException(Xeption innerException)
            : base(message: "Like dependency validation occurred, please try again.", innerException)
        { }
    }
}