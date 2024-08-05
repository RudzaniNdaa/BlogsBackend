using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Author> Authors { get; set; }

        public async ValueTask<Author> InsertAuthorAsync(Author author) =>
            await InsertAsync(author);

        public IQueryable<Author> SelectAllAuthors() =>
            SelectAll<Author>();

        public async ValueTask<Author> SelectAuthorByIdAsync(Guid authorId) =>
            await SelectAsync<Author>(authorId);

        public async ValueTask<Author> UpdateAuthorAsync(Author author) =>
            await UpdateAsync(author);

        public async ValueTask<Author> DeleteAuthorAsync(Author author) =>
            await DeleteAsync(author);
    }
}