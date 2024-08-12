using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;
using Blogs.API.Models.Comments.Exceptions;

namespace Blogs.API.Services.Foundations.Comments
{
    public partial class CommentService
    {
        private async ValueTask<Comment> WithRollback(
            ReturningCommentFunction returningCommentFunction,
            List<Type> rollbackExceptions)
        {
            try
            {
                return await returningCommentFunction();
            }
            catch (Exception ex)
            {
                if (rollbackExceptions != null && rollbackExceptions.Any(exception => exception == ex.GetType()))
                {
                    // Do rollback action here...

                    var commentRollbackException = new CommentRollbackException(ex);

                    // Throw rollback exception for upstream handling / distributed rollback
                    throw commentRollbackException;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}