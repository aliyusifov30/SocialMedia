using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.AccountCommands.AccountRegiterCommands;
using SocialMedia.Application.Features.Commands.AccountCommands.AccountLoginCommands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AccountLoginCommandResponse> Login(AccountLoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<AccountRegisterCommandResponse> Register(AccountRegisterCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        //[Authorize("Admin")]
        //[HttpPost]
        //public async Task CreateAdmin()
        //{

        //}


    }
}
