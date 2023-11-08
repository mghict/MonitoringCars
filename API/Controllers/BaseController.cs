using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace API.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public AppBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [NonAction]
        protected async Task<IActionResult> Match(FluentResults.Result result)
        {
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.Errors?.Select(p=>p.Message).ToArray());
        }

        [NonAction]
        protected async Task<IActionResult> Match<T>(FluentResults.Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.ValueOrDefault);

            return BadRequest(result.Errors?.Select(p => p.Message).ToArray());
        }
    }
}
