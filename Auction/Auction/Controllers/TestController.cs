
using Auction.Application.Common.Responces;
using Auction.Application.Features.Test;
using Auction.Controllers.Controls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Auction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]

        [Route("Create")]
        public async Task<IActionResult> CreateddAsync()
        {
            return Ok(await _mediator.Send(new CreateCameraQuery()));
        }
    }
}