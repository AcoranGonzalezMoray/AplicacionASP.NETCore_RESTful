using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArquitecture.Core.Interfaces.Services;
using CleanArquitecture.Core.Interfaces.Repositories;

namespace CleanArquitecture.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _tRepository;
        public BaseService(IBaseRepository<TEntity> _Repository) {
            _tRepository = _Repository;
        }



        public async Task AddAsync(TEntity entity)
        {
           await _tRepository.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await  _tRepository.GetAllAsync();
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
