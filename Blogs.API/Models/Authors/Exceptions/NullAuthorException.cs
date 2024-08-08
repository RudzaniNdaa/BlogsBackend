using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class NullAuthorException : Xeption
    {
        public NullAuthorException()
            : base(message: "Author is null.")
        { }
    }
}