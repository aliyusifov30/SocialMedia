using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands;

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
        [HttpPost]
        [Route("PostCreate")]
        public async Task<PostCreateCommandResponse> PostCreate([FromForm]PostCreateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
