using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;

namespace Blogs.API.Services.Foundations.Posts
{
    public interface IPostService
    {
        public ValueTask<Post> AddPostAsync(Post post);
        public IQueryable<Post> RetrieveAllPosts();
        public ValueTask<Post> RetrievePostByIdAsync(Guid postId);
        public ValueTask<Post> ModifyPostAsync(Post post);
        public ValueTask<Post> RemovePostAsync(Post post);
    }
}