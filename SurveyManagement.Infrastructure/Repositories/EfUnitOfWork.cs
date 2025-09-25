using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Infrastructure.Extensions;
using SurveyManagement.Infrastructure.Persistence;

namespace SurveyManagement.Infrastructure.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly SurveyDbContext _context;
        private readonly IMediator _mediator;

        public EfUnitOfWork(SurveyDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public IBaseRepository<T> Repository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            await _context.DispatchDomainEventsAsync(_mediator);
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}

