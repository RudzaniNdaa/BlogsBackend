using System;
using Xeptions;

namespace Blogs.API.Models.Replies.Exceptions
{
    public class NotFoundRepliesException : Xeption
    {
        public NotFoundRepliesException(Guid replyId)
            : base(message: $"Couldn't find reply with replyId: {replyId}.")
        { }
    }
}