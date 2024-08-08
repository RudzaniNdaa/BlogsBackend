using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class InvalidCommentException : Xeption
    {
        public InvalidCommentException()
            : base(message: "Invalid comment. Please correct the errors and try again.")
        { }
    }
}