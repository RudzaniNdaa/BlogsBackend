using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blogs.API.Models.Users
{
    public class Claim : IdentityUserClaim<Guid>
    {
        public virtual User User { get; set; }
    }
}