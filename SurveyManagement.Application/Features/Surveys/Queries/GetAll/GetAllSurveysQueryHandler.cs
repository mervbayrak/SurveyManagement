using AutoMapper;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetAll
{
    public class GetAllSurveysQueryHandler : IRequestHandler<GetAllSurveysQuery, SurveyResult<List<SurveyDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSurveysQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SurveyResult<List<SurveyDto>>> Handle(GetAllSurveysQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _unitOfWork.Repository<Survey>().GetAllAsync();
            var dtos = _mapper.Map<List<SurveyDto>>(surveys);
            return new SurveyResult<List<SurveyDto>>(dtos);
        }
    }
}
