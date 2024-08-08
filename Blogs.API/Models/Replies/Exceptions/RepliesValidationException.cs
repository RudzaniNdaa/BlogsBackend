using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class RepliesValidationException : Xeption
    {
        public RepliesValidationException(Xeption innerException)
            : base(message: "Rwply validation errors occurred, please try again.",
                  innerException)
        { }
    }
}