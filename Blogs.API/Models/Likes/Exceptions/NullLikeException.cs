using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class NullLikeException : Xeption
    {
        public NullLikeException()
            : base(message: "Like is null.")
        { }
    }
}