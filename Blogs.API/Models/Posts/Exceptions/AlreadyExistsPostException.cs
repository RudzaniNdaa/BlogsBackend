using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class AlreadyExistsPostException : Xeption
    {
        public AlreadyExistsPostException(Exception innerException)
            : base(message: "Post with the same Id already exists.", innerException)
        { }
    }
}