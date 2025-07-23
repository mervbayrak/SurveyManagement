using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands.UpdateSurvey
{
	public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, SurveyResult<Guid>>
	{
        private readonly IUnitOfWork _unitofWork;

        public UpdateSurveyCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<SurveyResult<Guid>> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = new Survey()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _unitofWork.Repository<Survey>().UpdateAsync(survey);
            await _unitofWork.SaveChangesAsync();

            return new SurveyResult<Guid>(survey.Id, "Anket başarıyla güncellendi.");
        }
    }
}

