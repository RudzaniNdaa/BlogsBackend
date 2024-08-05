using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Post> Posts { get; set; }

        public async ValueTask<Post> InsertPostAsync(Post post) =>
            await InsertAsync(post);

        public IQueryable<Post> SelectAllPosts() =>
            SelectAll<Post>();

        public async ValueTask<Post> SelectPostByIdAsync(Guid postId) =>
            await SelectAsync<Post>(postId);

        public async ValueTask<Post> UpdatePostAsync(Post post) =>
             await UpdateAsync(post);

        public async ValueTask<Post> DeletePostAsync(Post post) =>
            await DeleteAsync(post);
    }
}