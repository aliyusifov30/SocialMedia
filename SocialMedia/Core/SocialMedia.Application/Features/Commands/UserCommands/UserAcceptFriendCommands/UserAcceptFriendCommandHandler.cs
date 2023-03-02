using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.UserServices;
using SocialMedia.Application.Repositories.FriendRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.UserCommands.UserAcceptFriendCommands
{
    public class UserAcceptFriendCommandHandler : IRequestHandler<UserAcceptFriendCommandRequest, UserAcceptFriendCommandResponse>
    {
        private readonly IUserService _userService;

        public UserAcceptFriendCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserAcceptFriendCommandResponse> Handle(UserAcceptFriendCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.AcceptFriend(request.AcceptUserName, request.SentUserName);
            return new UserAcceptFriendCommandResponse()
            {

            };
        }
    }
}
