using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.API.Controllers;
using SurveyManagement.Application.Features.Surveys.Commands;

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
    }
}
