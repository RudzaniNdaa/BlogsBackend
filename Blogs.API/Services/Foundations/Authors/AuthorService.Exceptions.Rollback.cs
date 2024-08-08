using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Authors.Exceptions;

namespace Blogs.API.Services.Foundations.Authors
{
    public partial class AuthorService
    {
        private async ValueTask<Author> WithRollback(
            ReturningAuthorFunction returningAuthorFunction,
            List<Type> rollbackExceptions)
        {
            try
            {
                return await returningAuthorFunction();
            }
            catch (Exception ex)
            {
                if (rollbackExceptions != null && rollbackExceptions.Any(exception => exception == ex.GetType()))
                {
                    // Do rollback action here...

                    var authorRollbackException = new AuthorRollbackException(ex);

                    // Throw rollback exception for upstream handling / distributed rollback
                    throw authorRollbackException;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}