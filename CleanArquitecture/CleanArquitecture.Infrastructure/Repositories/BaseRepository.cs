using CleanArquitecture.Core.Interfaces.Repositories;
using CleanArquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal AppDbContext _context;
        internal DbSet<TEntity> dbSet;


        public BaseRepository(AppDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async  Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await dbSet.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(IEnumerable<TEntity> entitiesToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
