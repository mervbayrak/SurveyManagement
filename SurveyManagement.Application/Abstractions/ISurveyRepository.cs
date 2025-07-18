using System;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Abstractions
{
    public interface ISurveyRepository
    {
        Task AddAsync(Survey survey);
        Task<List<Survey>> GetAllAsync();
    }
}

