using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.Core.Entities;
using Ecommerse.Core.Repositories;
using Ecommerse.DAL.Context;

namespace Ecommerse.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AtesgahDbContext _context) : base(_context)
        {
        }
    }
}
