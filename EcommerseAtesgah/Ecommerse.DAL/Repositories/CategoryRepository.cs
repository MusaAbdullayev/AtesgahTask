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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AtesgahDbContext _context) : base(_context)
        {
        }
    }
}
