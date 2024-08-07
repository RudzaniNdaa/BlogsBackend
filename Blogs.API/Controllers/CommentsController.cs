using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Comments;
using Blogs.API.Services.Processings.Comments;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Blogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : RESTFulController
    {
        private readonly ICommentProcessingService commentProcessingService;

        public CommentsController(ICommentProcessingService commentProcessingService)
        {
            this.commentProcessingService = commentProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Comment>> PostCommentAsync(Comment comment)
        {
            Comment addComment =
                await this.commentProcessingService.UpsertCommentAsync(comment);

            return Ok(addComment);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Comment>> PutCommentAsync(Comment comment)
        {
            Comment editComment =
                 await this.commentProcessingService.UpsertCommentAsync(comment);

            return Ok(editComment);
        }

        [HttpGet]
        public ActionResult<IQueryable<Comment>> GetAllComments()
        {
            IQueryable comments =
                this.commentProcessingService.RetrieveAllComments();

            return Ok(comments);
        }

        [HttpGet("{commentId}")]
        public async ValueTask<ActionResult<Comment>> GetCommentByIdAsync(Guid commentId)
        {
            Comment maybeComment =
                await this.commentProcessingService.RetrieveCommentByIdAsync(commentId);

            return Ok(maybeComment);
        }

        [HttpDelete("{commentId}")]
        public async ValueTask<ActionResult<Comment>> DeleteCommentByIdAsync(Guid commentId)
        {
            Comment deleteComment =
                await this.commentProcessingService.TryRemoveCommentByIdAsync(commentId);

            return Ok(deleteComment);
        }
    }
}