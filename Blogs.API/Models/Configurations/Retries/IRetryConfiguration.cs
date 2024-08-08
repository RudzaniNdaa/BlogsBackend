using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Configurations.Retries
{
    public interface IRetryConfiguration
    {
        int MaxRetryAttempts { get; }
        TimeSpan DelayBetweenFailures { get; }
    }
}