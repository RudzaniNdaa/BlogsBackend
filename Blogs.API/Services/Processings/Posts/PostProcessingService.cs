using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Posts;
using Blogs.API.Services.Foundations.Posts;

namespace Blogs.API.Services.Processings.Posts
{
    public class PostProcessingService : IPostProcessingService
    {
        private readonly IPostService postService;

        public PostProcessingService(IPostService postService)
        {
            this.postService = postService;
        }

        public async ValueTask<Post> UpsertPostAsync(Post post)
        {
            IQueryable<Post> posts =
                this.postService.RetrieveAllPosts();

            Post maybePost =
                posts.FirstOrDefault(retrievedPost => retrievedPost.ID == post.ID);

            return maybePost switch 
            {
                { } => await this.postService.ModifyPostAsync(post),
                _ => await this.postService.AddPostAsync(post)
            };
        }

        public IQueryable<Post> RetrieveAllPosts()
        {
            return this.postService.RetrieveAllPosts();
        }

        public async ValueTask<Post> RetrievePostByIdAsync(Guid postId)
        {
            return await this.postService.RetrievePostByIdAsync(postId);
        }

        public async ValueTask<Post> TryRemovePostByIdAsync(Guid postId)
        {
            Post maybePost =
                await this.postService.RetrievePostByIdAsync(postId);

            return await this.postService.RemovePostAsync(maybePost);
        }
    }
}