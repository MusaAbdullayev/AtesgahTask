using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.Core.Entities;
using Ecommerse.Core.Repositories;
using Ecommerse.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.DAL.Repositories
{
    public class GenericRepository<T>(AtesgahDbContext _context):IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table = _context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public IQueryable<T> GetAll(params string[] includes)
        {

            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        public async Task<T?> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }



        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = Table.Where(expression);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        public Task<bool> IsExistAsync(int id)
          => Table.AnyAsync(t => t.Id == id);
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
          => await Table.AnyAsync(expression);

        public Task<int> SaveAsync()
          => _context.SaveChangesAsync();
    }
}

