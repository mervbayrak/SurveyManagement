using AutoMapper;
using MediatR;
using SurveyManagement.Application.Abstractions;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Wrappers;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetSurveyById
{
    public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQuery, SurveyResult<SurveyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSurveyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SurveyResult<SurveyDto>> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
        {
            var survey = await _unitOfWork.Repository<Survey>().GetByIdAsync(request.Id);

            if (survey == null)
                return SurveyResult<SurveyDto>.Fail("Anket bulunamadı.");

            var dto = _mapper.Map<SurveyDto>(survey);
            return SurveyResult<SurveyDto>.Success(dto, "Anket başarıyla getirildi.");
        }
    }
}
