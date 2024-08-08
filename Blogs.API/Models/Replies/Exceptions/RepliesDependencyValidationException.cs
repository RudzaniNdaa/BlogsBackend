using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class RepliesDependencyValidationException : Xeption
    {
        public RepliesDependencyValidationException(Xeption innerException)
            : base(message: "Rwply dependency validation occurred, please try again.", innerException)
        { }
    }
}