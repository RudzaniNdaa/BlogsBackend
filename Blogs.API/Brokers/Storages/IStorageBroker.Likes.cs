using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<Like> InsertLikeAsync(Like like);
        public IQueryable<Like> SelectAllLikes();
        public ValueTask<Like> SelectLikeByIdAsync(Guid likeId);
        public ValueTask<Like> UpdateLikeAsync(Like like);
        public ValueTask<Like> DeleteLikeAsync(Like like);
    }
}