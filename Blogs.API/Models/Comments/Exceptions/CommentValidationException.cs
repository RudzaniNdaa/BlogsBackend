using Xeptions;

namespace Blogs.API.Models.Comments.Exceptions
{
    public class CommentValidationException : Xeption
    {
        public CommentValidationException(Xeption innerException)
            : base(message: "Comment validation errors occurred, please try again.",
                  innerException)
        { }
    }
}