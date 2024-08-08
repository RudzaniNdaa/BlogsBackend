using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class InvalidPostException : Xeption
    {
        public InvalidPostException()
            : base(message: "Invalid post. Please correct the errors and try again.")
        { }
    }
}