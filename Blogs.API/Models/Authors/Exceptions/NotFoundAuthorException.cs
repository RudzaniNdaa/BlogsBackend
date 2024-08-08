using System;
using Xeptions;

namespace Blogs.API.Models.Authors.Exceptions
{
    public class NotFoundAuthorException : Xeption
    {
        public NotFoundAuthorException(Guid authorId)
            : base(message: $"Couldn't find author with authorId: {authorId}.")
        { }
    }
}