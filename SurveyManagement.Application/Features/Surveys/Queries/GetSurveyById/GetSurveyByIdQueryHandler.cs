using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetSurveyById
{
    public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQuery, SurveyDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSurveyByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SurveyDto> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
        {
            var survey = await _unitOfWork.Repository<Survey>().GetByIdAsync(request.Id);

            if (survey == null)
                return null;

            return new SurveyDto
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description
            };
        }
    }
}
