using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class LockedLikeException : Xeption
    {
        public LockedLikeException(Exception innerException)
            : base(message: "Locked like record exception, please try again later", innerException)
        {
        }
    }
}