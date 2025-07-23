using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, SurveyResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSurveyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SurveyResult<Guid>> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = new Survey
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Survey>().AddAsync(survey);
            await _unitOfWork.SaveChangesAsync();

            return new SurveyResult<Guid>(survey.Id, "Anket başarıyla oluşturuldu.");
        }
    }
}