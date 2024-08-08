using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class CommentDependencyException : Xeption
    {
        public CommentDependencyException(Xeption innerException) :
            base(message: "Comment dependency error occurred, contact support.", innerException)
        { }
    }
}