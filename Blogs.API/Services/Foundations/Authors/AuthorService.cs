using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Authors;

namespace Blogs.API.Services.Foundations.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IStorageBroker storageBroker;

        public AuthorService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
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