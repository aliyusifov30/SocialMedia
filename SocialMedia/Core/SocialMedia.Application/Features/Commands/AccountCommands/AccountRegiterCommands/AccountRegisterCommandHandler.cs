using AutoMapper;
using MediatR;
using SocialMedia.Application.Abstractions.Services.AccountServices;
using SocialMedia.Application.Abstractions.Services.LocalServices;
using SocialMedia.Application.DTOs.AccountDTOs;
using SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.AccountCommands.AccountRegiterCommands
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommandRequest, AccountRegisterCommandResponse>
    {

        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountRegisterCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountRegisterCommandResponse> Handle(AccountRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _accountService.Register(_mapper.Map<AccountRegisterDto>(request));
            return new AccountRegisterCommandResponse()
            {
                   
            };
        }
    }
}
