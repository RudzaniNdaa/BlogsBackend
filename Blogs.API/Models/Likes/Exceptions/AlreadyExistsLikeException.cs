using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class AlreadyExistsLikeException : Xeption
    {
        public AlreadyExistsLikeException(Exception innerException)
            : base(message: "Like with the same Id already exists.", innerException)
        { }
    }
}