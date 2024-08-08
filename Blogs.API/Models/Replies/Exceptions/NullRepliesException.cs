using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class NullRepliesException : Xeption
    {
        public NullRepliesException()
            : base(message: "Reply is null.")
        { }
    }
}