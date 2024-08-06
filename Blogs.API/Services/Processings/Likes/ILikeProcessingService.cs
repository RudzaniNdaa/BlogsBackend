using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;

namespace Blogs.API.Services.Processings.Likes
{
    public interface ILikeProcessingService
    {
        public ValueTask<Like> AddLikeAsync(Like like);
        public ValueTask<Like> TryRemoveLikeByIdAsync(Guid likeId);
    }
}