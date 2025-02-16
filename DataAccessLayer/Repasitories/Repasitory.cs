using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repasitories
{
    public class Repasitory<TEntity> : IRepasitory<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public Repasitory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {

            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity =  await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(id));

            }
            else
            {
                return entity;
            }
        }

        public  Task UpdateAsync(TEntity entity)
        {
              _dbContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
