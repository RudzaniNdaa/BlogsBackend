using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Models.Configurations.TryCatches
{
    public class Operation<T>
    {
        public Func<T> Execution { get; set; }
        public List<string> WithSecurityRoles { get; set; } = new List<string>();
        public List<Type> WithRetryOn { get; set; } = new List<Type>();
        public List<Type> WithRollbackOn { get; set; } = new List<Type>();
        public dynamic WithTracing { get; set; } = null;
    }
}