using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;
using Blogs.API.Services.Processings.Likes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Blogs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : RESTFulController
    {
        private readonly ILikeProcessingService likeProcessingService;

        public LikesController(ILikeProcessingService likeProcessingService)
        {
            this.likeProcessingService = likeProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Like>> PostLikeAsync(Like like)
        {
            Like addlike =
                await this.likeProcessingService.AddLikeAsync(like);

            return Ok(addlike);
        }

        [HttpDelete("{likeId}")]
        public async ValueTask<ActionResult<Like>> DeleteLikeByIdAsync(Guid likeId)
        {
            Like deleteLike =
                await this.likeProcessingService.TryRemoveLikeByIdAsync(likeId);

            return Ok(deleteLike);
        }
    }
}