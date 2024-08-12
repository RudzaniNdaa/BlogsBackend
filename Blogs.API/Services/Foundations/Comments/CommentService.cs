using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Comments;
using Blogs.API.Models.Comments.Exceptions;
using Blogs.API.Models.Configurations.Retries;
using Blogs.API.Models.Configurations.TryCatches;

namespace Blogs.API.Services.Foundations.Comments
{
    public partial class CommentService : ICommentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IRetryConfiguration retryConfiguration;

        public CommentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker,
            IRetryConfiguration retryConfiguration)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.retryConfiguration = retryConfiguration;
        }

        public ValueTask<Comment> AddCommentAsync(Comment comment) =>
            TryCatch(new Operation<ValueTask<Comment>>
            {
                Execution = async () =>
                {
                    ValidateCommentOnAdd(comment);

                    return await this.storageBroker.InsertCommentAsync(comment);
                },
                WithTracing = new 
                {
                    ActivityName = nameof(this.AddCommentAsync),
                    Tags = new Dictionary<string, string> { {"CommentID", comment?.ID.ToString()}},
                    Baggage = new Dictionary<string, string> { {"CommentID", comment?.ID.ToString()}},
                },
                WithSecurityRoles = new List<string>() { "Administrators", "Users" },
                WithRetryOn = new List<Type>() { typeof(TimeoutException) },
                WithRollbackOn = new List<Type>() { typeof(CommentDependencyValidationException) }
            });

        public IQueryable<Comment> RetrieveAllComments() =>
            TryCatch(() => this.storageBroker.SelectAllComments());

        public ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId) =>
            TryCatch(async () => 
            {
                ValidateCommentId(commentId);

                Comment maybeComment =
                    await this.storageBroker.SelectCommentByIdAsync(commentId);

                ValidateStorageComment(maybeComment, commentId);

                return maybeComment;
            });

        public ValueTask<Comment> ModifyCommentAsync(Comment comment) =>
            TryCatch(new Operation<ValueTask<Comment>>
            {
                Execution = async () =>
                {
                    ValidateCommentOnModify(comment);

                    return await this.storageBroker.UpdateCommentAsync(comment);
                },
                WithTracing = new 
                {
                    ActivityName = nameof(this.ModifyCommentAsync),
                    Tags = new Dictionary<string, string> { {"CommentID", comment?.ID.ToString()}},
                    Baggage = new Dictionary<string, string> { {"CommentID", comment?.ID.ToString()}},
                },
                WithSecurityRoles = new List<string>() { "Administrators", "Users" },
                WithRetryOn = new List<Type>() { typeof(TimeoutException) },
                WithRollbackOn = new List<Type>() { typeof(CommentDependencyValidationException) }
            });

        public ValueTask<Comment> RemoveCommentAsync(Comment comment) =>
            TryCatch(async () => 
            {
                ValidateCommentIsNotNull(comment);
                
                return await this.storageBroker.DeleteCommentAsync(comment);
            });
    }
}