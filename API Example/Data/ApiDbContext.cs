
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecuringWebApi.Data.Entities;

namespace SecuringWebApi.Data
{
    public class ApiDbContext : IdentityDbContext<IdentityUser>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Post> Posts { get; set; }
    }
}
