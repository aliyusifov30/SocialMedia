using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.UserCommands.UserAcceptFriendCommands;
using SocialMedia.Application.Features.Commands.UserCommands.UserAddFriendCommands;
using System.Data;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("AddFriend")]
        public async Task<IActionResult> AddFriend(UserAddFriendCommandRequest request)
        {
            request.FromUserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("AcceptFriend")]
        public async Task<IActionResult> AcceptFriend(UserAcceptFriendCommandRequest request)
        {
            request.AcceptUserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
