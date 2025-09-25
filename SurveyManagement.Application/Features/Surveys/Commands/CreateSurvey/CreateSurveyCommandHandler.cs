using System;
using MediatR;
using SurveyManagement.Application.Abstractions;
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
            var survey = Survey.Create(request.Title, request.Description);

            await _unitOfWork.Repository<Survey>().AddAsync(survey);
            await _unitOfWork.SaveChangesAsync();

            return new SurveyResult<Guid>(survey.Id, "Anket başarıyla oluşturuldu.");
        }
    }
}