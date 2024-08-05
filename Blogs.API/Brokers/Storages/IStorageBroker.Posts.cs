using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;

namespace Blogs.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        public ValueTask<Post> InsertPostAsync(Post post);
        public IQueryable<Post> SelectAllPosts();
        public ValueTask<Post> SelectPostByIdAsync(Guid postId);
        public ValueTask<Post> UpdatePostAsync(Post post);
        public ValueTask<Post> DeletePostAsync(Post post);
    }
}