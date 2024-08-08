using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class AuthorDependencyException : Xeption
    {
        public AuthorDependencyException(Xeption innerException) :
            base(message: "Author dependency error occurred, contact support.", innerException)
        { }
    }
}