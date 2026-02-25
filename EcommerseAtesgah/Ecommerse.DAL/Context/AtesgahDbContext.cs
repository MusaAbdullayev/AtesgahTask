using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.DAL.Context
{
    public class AtesgahDbContext : DbContext
    {
        public AtesgahDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtesgahDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
