using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LikeValidationException : Xeption
    {
        public LikeValidationException(Xeption innerException)
            : base(message: "Like validation errors occurred, please try again.",
                  innerException)
        { }
    }
}