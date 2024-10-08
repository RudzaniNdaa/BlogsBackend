using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blogs.API.Models.Users
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}