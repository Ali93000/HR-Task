using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(long Id);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> GetLastOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);
        Task RemoveById(int id);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
