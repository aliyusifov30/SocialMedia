using MediatR;
using SocialMedia.Application.Abstractions.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.UserCommands.UserAddFriendCommands
{
    public class UserAddFriendCommandHandler : IRequestHandler<UserAddFriendCommandRequest, UserAddFriendCommandResponse>
    {
        private readonly IUserService _userService;

        public UserAddFriendCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserAddFriendCommandResponse> Handle(UserAddFriendCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ToUserName.Equals(request.FromUserName)) throw new Exception("you can't friend with yourself!");
            await _userService.AddFriend(request.FromUserName, request.ToUserName);
            return new UserAddFriendCommandResponse()
            {

            };
        }
    }
}
