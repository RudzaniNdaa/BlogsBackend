using System;
using Xeptions;

namespace Blogs.API.Models.PostAttachments.Exceptions
{
    public class NotFoundPostAttachmentException : Xeption
    {
        public NotFoundPostAttachmentException(Guid postId)
            : base(message: $"Couldn't find post with postId: {postId}.")
        { }
    }
}