using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class NullPostException : Xeption
    {
        public NullPostException()
            : base(message: "Post is null.")
        { }
    }
}