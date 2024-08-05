using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<Author> InsertAuthorAsync(Author author);
        public IQueryable<Author> SelectAllAuthors();
        public ValueTask<Author> SelectAuthorByIdAsync(Guid authorId);
        public ValueTask<Author> UpdateAuthorAsync(Author author);
        public ValueTask<Author> DeleteAuthorAsync(Author author);
    }
}