using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;

namespace Blogs.API.Services.Processings.Authors
{
    public interface IAuthorProcessingService
    {
        public ValueTask<Author> UpsertAuthorAsync(Author author);
        public IQueryable<Author> RetrieveAllAuthors();
        public ValueTask<Author> RetrieveAuthorByIdAsync(Guid authorId);
        public ValueTask<Author> TryRemoveAuthorByIdAsync(Guid authorId);
    }
}