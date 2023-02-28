using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands;
using SocialMedia.Application.Features.Queries.PostGetAllQueries;
using SocialMedia.Application.Features.Queries.PostGetQueries;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase   
    {

        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("PostCreate")]
        public async Task<IActionResult> PostCreate([FromForm]PostCreateCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        [Route("PostGet")]
        public async Task<IActionResult> PostGet(PostGetQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        [Route("PostGetAll")]
        public async Task<IActionResult> PostGetAll(PostGetAllQueryRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
