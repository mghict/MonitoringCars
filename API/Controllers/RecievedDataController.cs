using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/recieved-data")]
    public class RecievedDataController : AppBaseController
    {

        public RecievedDataController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CreateData(int a, string b, decimal c1, decimal c2, decimal c3, decimal c4, decimal c5, long c6, DateTime c7, int c8)
        {
            Application.RecievedData.Commands.RecievedDataCreateCommand command =
                new Application.RecievedData.Commands.RecievedDataCreateCommand(a, b, c1, c2, c3, c4, c5, c6, c7, c8);

            var result = await _mediator.Send(command);
            return await Match(result);

            //if (result.IsSuccess)
            //    return Ok();

            //return BadRequest(result.Errors);

        }

        
    }
}
