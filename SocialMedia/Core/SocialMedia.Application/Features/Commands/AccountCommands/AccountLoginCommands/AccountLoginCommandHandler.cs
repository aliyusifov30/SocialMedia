using AutoMapper;
using MediatR;
using SocialMedia.Application.Abstractions.Services.AccountServices;
using SocialMedia.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.AccountCommands.AccountLoginCommands
{
    public class AccountLoginCommandHandler : IRequestHandler<AccountLoginCommandRequest, AccountLoginCommandResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountLoginCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountLoginCommandResponse> Handle(AccountLoginCommandRequest request, CancellationToken cancellationToken)
        {
            string token = await _accountService.Login(_mapper.Map<AccountLoginDto>(request));
            return new AccountLoginCommandResponse
            {
                Token = token
            };
        }
    }
}
