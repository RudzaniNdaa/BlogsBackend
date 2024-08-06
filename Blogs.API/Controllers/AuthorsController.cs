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

        [HttpPut]
        public async ValueTask<ActionResult<Author>> PutAuthorAsync(Author author)
        {
            Author addAuthor =
                 await this.authorProcessingService.UpsertAuthorAsync(author);

                return Ok(addAuthor);
        }
    }
}