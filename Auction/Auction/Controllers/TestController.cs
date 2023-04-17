
using Auction.Application.Common.Responces;
using Auction.Application.Features.Test;
using Auction.Controllers.Controls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateAsync()
        {
            return Ok(await Mediator.Send(new CreateCameraQuery()));
        }
    }
}