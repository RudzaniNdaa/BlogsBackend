using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Authors.Exceptions;
using Blogs.API.Models.Configurations.Retries;
using Blogs.API.Models.Configurations.TryCatches;

namespace Blogs.API.Services.Foundations.Authors
{
    public partial class AuthorService : IAuthorService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IRetryConfiguration retryConfiguration;

        public AuthorService(
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

        public ValueTask<Author> AddAuthorAsync(Author author) =>
            TryCatch(new Operation<ValueTask<Author>>
            {
                Execution = async () =>
                {
                    ValidateAuthorOnAdd(author);

                    return await this.storageBroker.InsertAuthorAsync(author);
                },
                WithTracing = new 
                {
                    ActivityName = nameof(this.AddAuthorAsync),
                    Tags = new Dictionary<string, string> { {"AuthorID", author?.ID.ToString()}},
                    Baggage = new Dictionary<string, string> { {"AuthorID", author?.ID.ToString()}},
                },
                WithSecurityRoles = new List<string>() { "Administrators", "Users" },
                WithRetryOn = new List<Type>() { typeof(TimeoutException) },
                WithRollbackOn = new List<Type>() { typeof(AuthorDependencyValidationException) }
            });
        

        public IQueryable<Author> RetrieveAllAuthors() =>
            TryCatch(() => this.storageBroker.SelectAllAuthors());
        
        public ValueTask<Author> RetrieveAuthorByIdAsync(Guid authorId) =>
            TryCatch(async () => 
            {
                ValidateAuthorId(authorId);

                Author maybeAuthor =
                    await this.storageBroker.SelectAuthorByIdAsync(authorId);

                ValidateStorageAuthor(maybeAuthor, authorId);

                return maybeAuthor;
            });


        public ValueTask<Author> ModifyAuthorAsync(Author author) =>
            TryCatch(new Operation<ValueTask<Author>>
            {
                Execution = async () =>
                {
                    ValidateAuthorOnModify(author);

                    return await this.storageBroker.UpdateAuthorAsync(author);
                },
                WithTracing = new 
                {
                    ActivityName = nameof(this.ModifyAuthorAsync),
                    Tags = new Dictionary<string, string> { {"AuthorID", author?.ID.ToString()}},
                    Baggage = new Dictionary<string, string> { {"AuthorID", author?.ID.ToString()}},
                },
                WithSecurityRoles = new List<string>() { "Administrators", "Users" },
                WithRetryOn = new List<Type>() { typeof(TimeoutException) },
                WithRollbackOn = new List<Type>() { typeof(AuthorDependencyValidationException) }
            });

        public ValueTask<Author> RemoveAuthorAsync(Author author) =>
            TryCatch(async () => 
            {
                ValidateAuthorIsNotNull(author);
                
                return await this.storageBroker.DeleteAuthorAsync(author);
            });
        
    }
}