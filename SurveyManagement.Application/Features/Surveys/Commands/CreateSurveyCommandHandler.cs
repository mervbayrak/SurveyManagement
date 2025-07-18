using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, Guid>
    {
        private readonly ISurveyRepository _repository;

        public CreateSurveyCommandHandler(ISurveyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = new Survey
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(survey);
            return survey.Id;
        }
    }
}