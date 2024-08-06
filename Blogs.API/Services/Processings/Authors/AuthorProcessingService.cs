using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Services.Foundations.Authors;

namespace Blogs.API.Services.Processings.Authors
{
    public class AuthorProcessingService : IAuthorProcessingService
    {
        private readonly IAuthorService authorService;

        public AuthorProcessingService(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public async ValueTask<Author> UpsertAuthorAsync(Author author)
        {
            IQueryable<Author> authors =
                this.authorService.RetrieveAllAuthors();
            Author maybeAuthor =
                authors.FirstOrDefault(reteievedAuthor => reteievedAuthor.ID == author.ID);

            return maybeAuthor switch
            {
                { } => await this.authorService.ModifyAuthorAsync(author),
                _ => await this.authorService.AddAuthorAsync(author)
            };
        }

        public IQueryable<Author> RetrieveAllAuthors()
        {
            return this.authorService.RetrieveAllAuthors();
        }

        public async ValueTask<Author> RetrieveAuthorByIdAsync(Guid authorId)
        {
            return await this.authorService.RetrieveAuthorByIdAsync(authorId);
        }

        public async ValueTask<Author> TryRemoveAuthorByIdAsync(Guid authorId)
        {
            Author maybeAuthor =
                await this.authorService.RetrieveAuthorByIdAsync(authorId);

            return await this.authorService.RemoveAuthorAsync(maybeAuthor);
        }
    }
}