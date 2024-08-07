using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Services.Processings.Authors;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Blogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : RESTFulController
    {
        private readonly IAuthorProcessingService authorProcessingService;

        public AuthorsController(IAuthorProcessingService authorProcessingService)
        {
            this.authorProcessingService = authorProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Author>> PostAuthorAsync(Author author)
        {
            Author addAuthor =
                await this.authorProcessingService.UpsertAuthorAsync(author);

            return Ok(addAuthor);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Author>> PutAuthorAsync(Author author)
        {
            Author addAuthor =
                 await this.authorProcessingService.UpsertAuthorAsync(author);

            return Ok(addAuthor);
        }

        [HttpGet]
        public ActionResult<IQueryable<Author>> GetAllAuthors()
        {
            IQueryable authors =
                this.authorProcessingService.RetrieveAllAuthors();

            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public async ValueTask<ActionResult<Author>> GetAuthorByIdAsync(Guid authorId)
        {
            Author maybeAuthor =
                await this.authorProcessingService.RetrieveAuthorByIdAsync(authorId);

            return Ok(maybeAuthor);
        }

        [HttpDelete("{authorId}")]
        public async ValueTask<ActionResult<Author>> DeleteAuthorByIdAsync(Guid authorId)
        {
            Author deleteAuthor =
                await this.authorProcessingService.TryRemoveAuthorByIdAsync(authorId);

            return Ok(deleteAuthor);
        }

    }
}