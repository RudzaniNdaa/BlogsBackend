using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Users;
using EFxceptions.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsIdentityContext<User, Role, Guid>, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(
                    name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}