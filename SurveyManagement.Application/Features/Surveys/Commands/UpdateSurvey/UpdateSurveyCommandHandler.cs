using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Messaging.Events.SurveyUpdated;
using SurveyManagement.Application.Messaging.Interfaces;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands.UpdateSurvey
{
	public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, SurveyResult<Guid>>
	{
        private readonly IUnitOfWork _unitofWork;
        private readonly IEventPublisher _eventPublisher;

        public UpdateSurveyCommandHandler(IUnitOfWork unitofWork, IEventPublisher eventPublisher)
        {
            _unitofWork = unitofWork;
            _eventPublisher = eventPublisher;
        }

        public async Task<SurveyResult<Guid>> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = Survey.Create(request.Title, request.Description);

            await _unitofWork.Repository<Survey>().UpdateAsync(survey);
            await _unitofWork.SaveChangesAsync();

            await _eventPublisher.Publish(new SurveyUpdatedEvent()
            {
                SurveyId = survey.Id,
                Description = survey.Description,
                Title = survey.Title
            });

            return new SurveyResult<Guid>(survey.Id, "Anket başarıyla güncellendi.");
        }
    }
}

