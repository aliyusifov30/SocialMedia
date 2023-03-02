using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using SocialMedia.Application.Features.Commands.PostCommands.PostArchiveCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostCommentCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostCommentRemoveCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostDeleteCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostLikeCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostUnlikeCommands;
using SocialMedia.Application.Features.Queries.PostGetAllQueries;
using SocialMedia.Application.Features.Queries.PostGetQueries;
using SocialMedia.Domain.Entities;

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

        //todo post save 
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
        [HttpDelete]
        [Route("PostDelete")]
        public async Task<IActionResult> PostDelete(PostDeleteCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("PostArchive")]
        public async Task<IActionResult> PostArchive(PostArchiveCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        } 


        [HttpGet]
        [Route("PostGet")]
        public async Task<IActionResult> PostGet(PostGetQueryRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("PostGetAll")]
        public async Task<IActionResult> PostGetAll(PostGetAllQueryRequest request)
        {
            if(User.Identity.IsAuthenticated)
                request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("PostLike")]
        public async Task<IActionResult> PostLike(PostLikeCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("PostUnlike")]
        public async Task<IActionResult> PostUnLike(PostUnlikeCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        [Route("PostComment")]
        public async Task<IActionResult> PostComment(PostCommentCommandRequest request)
        {
            request.UserName = User.Identity.Name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [Authorize(Roles = "Member")]
        [HttpDelete]
        [Route("PostCommentRemove")]
        public async Task<IActionResult> PostCommentRemove(PostCommentRemoveCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }




    }
}
