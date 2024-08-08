using System;
using Xeptions;

namespace Blogs.API.Models.Posts.Exceptions
{
    public class NotFoundPostException : Xeption
    {
        public NotFoundPostException(Guid postId)
            : base(message: $"Couldn't find post with postId: {postId}.")
        { }
    }
}