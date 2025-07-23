using MediatR;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Wrappers;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetAll
{
    public class GetAllSurveysQuery : IRequest<SurveyResult<List<SurveyDto>>>
    {
    }
}
