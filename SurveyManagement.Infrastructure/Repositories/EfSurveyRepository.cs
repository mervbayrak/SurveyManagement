using System;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Infrastructure.Persistence;

namespace SurveyManagement.Infrastructure.Repositories
{
    public class EfSurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _context;

        public EfSurveyRepository(SurveyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
        }

        public Task<List<Survey>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
