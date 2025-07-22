using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.API.Controllers;
using SurveyManagement.Application.Features.Surveys.Commands.CreateSurvey;
using SurveyManagement.Application.Features.Surveys.Queries.GetAll;
using SurveyManagement.Application.Features.Surveys.Queries.GetSurveyById;

namespace SurveyManagement.WebAPI.Controllers
{
    public class SurveyController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SurveyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSurveyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSurveysQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSurveyByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
