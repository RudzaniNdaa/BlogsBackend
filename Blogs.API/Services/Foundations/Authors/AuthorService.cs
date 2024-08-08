using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Configurations.Retries;

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

        public async ValueTask<Author> AddAuthorAsync(Author author)
        {
            return await this.storageBroker.InsertAuthorAsync(author);
        }

        public IQueryable<Author> RetrieveAllAuthors()
        {
            return this.storageBroker.SelectAllAuthors();
        }

        public async ValueTask<Author> RetrieveAuthorByIdAsync(Guid authorId)
        {
            return await this.storageBroker.SelectAuthorByIdAsync(authorId);
        }

        public async ValueTask<Author> ModifyAuthorAsync(Author author)
        {
            return await this.storageBroker.UpdateAuthorAsync(author);
        }

        public async ValueTask<Author> RemoveAuthorAsync(Author author)
        {
            return await this.storageBroker.DeleteAuthorAsync(author);
        }
    }
}