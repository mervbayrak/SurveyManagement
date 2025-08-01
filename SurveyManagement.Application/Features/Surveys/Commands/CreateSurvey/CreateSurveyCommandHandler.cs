using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.Messaging.Events.SurveyCreated;
using SurveyManagement.Application.Messaging.Interfaces;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, SurveyResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _publisher;

        public CreateSurveyCommandHandler(IUnitOfWork unitOfWork, IEventPublisher publisher)
        {
            _unitOfWork = unitOfWork;
            _publisher = publisher;
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

            await _publisher.Publish(new SurveyCreatedEvent
            {
                SurveyId = survey.Id,
                Title = survey.Title,
                Description = survey.Description
            });

            return new SurveyResult<Guid>(survey.Id, "Anket başarıyla oluşturuldu.");
        }
    }
}