using HR.DAL.Domain;
using HR.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entitis;
        public GenericRepositoryAsync(DbContext context)
        {
            _context = context;
            _entitis = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entitis.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entitis.AddRangeAsync(entities);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entitis.AsNoTracking().ToListAsync();
        }


        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _entitis.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(long Id)
        {
            return await _entitis.FindAsync(Id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _entitis.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> GetLastOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            var list = await _entitis.AsNoTracking().Where(expression).ToListAsync();
            var lastItem = list.LastOrDefault();
            return lastItem;
        }

        public void Remove(T entity)
        {
            _entitis.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            T itemToDelete = await _entitis.FindAsync(id);
            _entitis.Remove(itemToDelete);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entitis.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            //_entitis.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            _entitis.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _entitis.UpdateRange(entities);
        }
    }
}
