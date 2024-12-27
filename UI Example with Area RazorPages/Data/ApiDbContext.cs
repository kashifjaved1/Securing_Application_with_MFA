
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Data.Entities;

namespace UI.Data
{
    public class ApiDbContext : IdentityDbContext<IdentityUser>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Post> Posts { get; set; }
    }
}
