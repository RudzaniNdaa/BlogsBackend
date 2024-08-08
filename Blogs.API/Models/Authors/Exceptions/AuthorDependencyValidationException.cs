using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AuthorDependencyValidationException : Xeption
    {
        public AuthorDependencyValidationException(Xeption innerException)
            : base(message: "Author dependency validation occurred, please try again.", innerException)
        { }
    }
}