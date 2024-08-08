using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class PostValidationException : Xeption
    {
        public PostValidationException(Xeption innerException)
            : base(message: "Post validation errors occurred, please try again.",
                  innerException)
        { }
    }
}