using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Likes;

namespace Blogs.API.Services.Foundations.Likes
{
    public class LikeService : ILikeService
    {
        private readonly IStorageBroker storageBroker;

        public LikeService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Like> AddLikeAsync(Like like)
        {
            return await this.storageBroker.InsertLikeAsync(like);
        }

        public IQueryable<Like> RetrieveAllLikes()
        {
            return this.storageBroker.SelectAllLikes();
        }

        public async ValueTask<Like> RetrieveLikeByIdAsync(Guid likeId)
        {
            return await this.storageBroker.SelectLikeByIdAsync(likeId);
        }

        public async ValueTask<Like> ModifyLikeAsync(Like like)
        {
            return await this.storageBroker.UpdateLikeAsync(like);
        }

        public async ValueTask<Like> RemoveLikeAsync(Like like)
        {
            return await this.storageBroker.DeleteLikeAsync(like);
        }
    }
}