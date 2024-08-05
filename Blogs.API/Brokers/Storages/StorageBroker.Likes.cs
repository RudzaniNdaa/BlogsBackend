using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Likes;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Like> Likes { get; set; }

        public async ValueTask<Like> InsertLikeAsync(Like like) =>
            await InsertAsync(like);

        public IQueryable<Like> SelectAllLikes() =>
            SelectAll<Like>();

        public async ValueTask<Like> SelectLikeByIdAsync(Guid likeId) =>
            await SelectAsync<Like>(likeId);

        public async ValueTask<Like> UpdateLikeAsync(Like like) =>
            await UpdateAsync(like);

        public async ValueTask<Like> DeleteLikeAsync(Like like) =>
            await DeleteAsync(like);
    }
}