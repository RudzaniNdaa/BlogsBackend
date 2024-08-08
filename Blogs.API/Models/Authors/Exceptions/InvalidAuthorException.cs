using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class InvalidAuthorException : Xeption
    {
        public InvalidAuthorException()
            : base(message: "Invalid author. Please correct the errors and try again.")
        { }
    }
}