using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class CommentDependencyValidationException : Xeption
    {
        public CommentDependencyValidationException(Xeption innerException)
            : base(message: "Comment dependency validation occurred, please try again.", innerException)
        { }
    }
}