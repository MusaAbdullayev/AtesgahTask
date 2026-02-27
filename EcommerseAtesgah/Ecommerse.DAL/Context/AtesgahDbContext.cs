
using Ecommerse.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.DAL.Context
{
    public class AtesgahDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AtesgahDbContext(DbContextOptions options) : base(options)
        {
        }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtesgahDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
