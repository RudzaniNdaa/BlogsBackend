using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class InvalidRepliesException : Xeption
    {
        public InvalidRepliesException()
            : base(message: "Invalid reply. Please correct the errors and try again.")
        { }
    }
}