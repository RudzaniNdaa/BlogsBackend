using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Models.Configurations.Retries;
using Blogs.API.Models.Posts;

namespace Blogs.API.Services.Foundations.Posts
{
    public partial class PostService : IPostService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IRetryConfiguration retryConfiguration;

        public PostService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker,
            IRetryConfiguration retryConfiguration)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.retryConfiguration = retryConfiguration;
        }

        public async ValueTask<Post> AddPostAsync(Post post)
        {
            return await this.storageBroker.InsertPostAsync(post);
        }

        public IQueryable<Post> RetrieveAllPosts()
        {
            return this.storageBroker.SelectAllPosts();
        }

        public async ValueTask<Post> RetrievePostByIdAsync(Guid postId)
        {
            return await this.storageBroker.SelectPostByIdAsync(postId);
        }

        public async ValueTask<Post> ModifyPostAsync(Post post)
        {
            return await this.storageBroker.UpdatePostAsync(post);
        }

        public async ValueTask<Post> RemovePostAsync(Post post)
        {
            return await this.storageBroker.DeletePostAsync(post);
        }
    }
}