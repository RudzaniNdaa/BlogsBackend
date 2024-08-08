using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Configurations.Retries
{
    public class RetryConfiguration : IRetryConfiguration
    {
        public RetryConfiguration()
        {
            MaxRetryAttempts = 3;
            DelayBetweenFailures = TimeSpan.FromSeconds(2);
        }

        public RetryConfiguration(int maxRetryAttempts, TimeSpan delayBetweenFailures)
        {
            MaxRetryAttempts = maxRetryAttempts;
            DelayBetweenFailures = delayBetweenFailures;
        }

        public int MaxRetryAttempts { get; private set; }
        public TimeSpan DelayBetweenFailures { get; private set; }
    }
}