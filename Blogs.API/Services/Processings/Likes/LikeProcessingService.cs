using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;
using Blogs.API.Services.Foundations.Likes;

namespace Blogs.API.Services.Processings.Likes
{
    public class LikeProcessingService : ILikeProcessingService
    {
        private readonly ILikeService likeService;

        public LikeProcessingService(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        public async ValueTask<Like> AddLikeAsync(Like like)
        {
            return await this.likeService.AddLikeAsync(like);
        }

        public async ValueTask<Like> TryRemoveLikeByIdAsync(Guid likeId)
        {
            Like maybeLike =
                await this.likeService.RetrieveLikeByIdAsync(likeId);

            return await this.likeService.RemoveLikeAsync(maybeLike);
        }
    }
}