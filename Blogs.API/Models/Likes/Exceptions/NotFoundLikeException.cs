using System;
using Xeptions;

namespace Blogs.API.Models.Likes.Exceptions
{
    public class NotFoundLikeException : Xeption
    {
        public NotFoundLikeException(Guid likeId)
            : base(message: $"Couldn't find like with likeId: {likeId}.")
        { }
    }
}