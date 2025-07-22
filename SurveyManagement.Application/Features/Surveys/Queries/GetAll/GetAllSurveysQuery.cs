using MediatR;
using SurveyManagement.Application.DTOs;

namespace SurveyManagement.Application.Features.Surveys.Queries.GetAll
{
    public class GetAllSurveysQuery : IRequest<List<SurveyDto>>
    {
    }
}
