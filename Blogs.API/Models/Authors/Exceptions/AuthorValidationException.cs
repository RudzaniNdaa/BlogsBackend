using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AuthorValidationException : Xeption
    {
        public AuthorValidationException(Xeption innerException)
            : base(message: "Author validation errors occurred, please try again.",
                  innerException)
        { }
    }
}