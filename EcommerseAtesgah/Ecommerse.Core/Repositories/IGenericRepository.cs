using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerse.Core.Entities;

namespace Ecommerse.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(params string[] includes);
        Task<T?> GetByIdAsync(int id, params string[] includes);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, params string[] include);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        Task<int> SaveAsync();
        Task<bool> IsExistAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    }
}
