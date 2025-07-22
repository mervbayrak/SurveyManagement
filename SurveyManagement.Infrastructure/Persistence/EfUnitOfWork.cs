using System;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Infrastructure.Repositories;

namespace SurveyManagement.Infrastructure.Persistence
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly SurveyDbContext _context;

        public EfUnitOfWork(SurveyDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> Repository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}

