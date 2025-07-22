using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetAll
{
    public class GetAllSurveysQueryHandler : IRequestHandler<GetAllSurveysQuery, List<SurveyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSurveysQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SurveyDto>> Handle(GetAllSurveysQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _unitOfWork.Repository<Survey>().GetAllAsync();

            return surveys.Select(s => new SurveyDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            }).ToList();
        }
    }
}
