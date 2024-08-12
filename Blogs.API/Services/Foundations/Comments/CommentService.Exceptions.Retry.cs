using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;

namespace Blogs.API.Services.Foundations.Comments
{
    public partial class CommentService
    {
        private async ValueTask<Comment> WithRetry(
            ReturningCommentFunction returningCommentFunction,
            List<Type> retryExceptionTypes)
        {
            var attempts = 0;

            while (true)
            {
                try
                {
                    attempts++;
                    return await returningCommentFunction();
                }
                catch (Exception ex)
                {
                    if (retryExceptionTypes.Any(exception => exception == ex.GetType()))
                    {
                        this.loggingBroker
                            .LogInformation(
                                $"Error found. Retry attempt {attempts}/{this.retryConfiguration.MaxRetryAttempts}. " +
                                    $"Exception: {ex.Message}");

                        if (attempts == this.retryConfiguration.MaxRetryAttempts)
                        {
                            throw;
                        }

                        Task.Delay(this.retryConfiguration.DelayBetweenFailures).Wait();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}