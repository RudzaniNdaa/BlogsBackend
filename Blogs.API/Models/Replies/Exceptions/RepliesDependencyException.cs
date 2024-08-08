using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class RepliesDependencyException : Xeption
    {
        public RepliesDependencyException(Xeption innerException) :
            base(message: "Rwply dependency error occurred, contact support.", innerException)
        { }
    }
}