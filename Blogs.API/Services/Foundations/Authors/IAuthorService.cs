using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;

namespace Blogs.API.Services.Foundations.Authors
{
    public interface IAuthorService
    {
        public ValueTask<Author> AddAuthorAsync(Author author);
        public IQueryable<Author> RetrieveAllAuthors();
        public ValueTask<Author> RetrieveAuthorByIdAsync(Guid authorId);
        public ValueTask<Author> ModifyAuthorAsync(Author author);
        public ValueTask<Author> RemoveAuthorAsync(Author author);
    }
}