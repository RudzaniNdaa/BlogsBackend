using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;

namespace Blogs.API.Services.Processings.Posts
{
    public interface IPostProcessingService
    {
        public ValueTask<Post> UpsertPostAsync(Post post);
        public IQueryable<Post> RetrieveAllPosts();
        public ValueTask<Post> RetrievePostByIdAsync(Guid postId);
        public ValueTask<Post> TryRemovePostByIdAsync(Guid postId);
    }
}