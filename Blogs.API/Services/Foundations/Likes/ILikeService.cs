using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;

namespace Blogs.API.Services.Foundations.Likes
{
    public interface ILikeService
    {
        public ValueTask<Like> AddLikeAsync(Like like);
        public IQueryable<Like> RetrieveAllLikes();
        public ValueTask<Like> RetrieveLikeByIdAsync(Guid likeId);
        public ValueTask<Like> ModifyLikeAsync(Like like);
        public ValueTask<Like> RemoveLikeAsync(Like like);
    }
}