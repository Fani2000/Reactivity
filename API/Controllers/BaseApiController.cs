using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.value != null)
            {
                return Ok(result.value);
            }

            if (result.IsSuccess && result.value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}