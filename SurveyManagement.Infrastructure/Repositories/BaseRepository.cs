using System;
using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Infrastructure.Persistence;

namespace SurveyManagement.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        protected readonly SurveyDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(SurveyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }


        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }

}

