using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class NullCommentException : Xeption
    {
        public NullCommentException()
            : base(message: "Comment is null.")
        { }
    }
}