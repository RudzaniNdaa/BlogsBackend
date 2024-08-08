using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class InvalidLikeException : Xeption
    {
        public InvalidLikeException()
            : base(message: "Invalid like. Please correct the errors and try again.")
        { }
    }
}