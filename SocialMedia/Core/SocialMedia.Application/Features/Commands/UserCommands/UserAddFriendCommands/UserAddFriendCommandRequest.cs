using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.UserCommands.UserAddFriendCommands
{
    public class UserAddFriendCommandRequest : IRequest<UserAddFriendCommandResponse>
    {
        public string? FromUserName { get; set; }
        public string ToUserName { get; set; }
    }
}
