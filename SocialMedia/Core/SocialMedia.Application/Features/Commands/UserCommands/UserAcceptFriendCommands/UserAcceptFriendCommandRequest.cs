using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.UserCommands.UserAcceptFriendCommands
{
    public class UserAcceptFriendCommandRequest : IRequest<UserAcceptFriendCommandResponse>
    {
        public string? AcceptUserName { get; set; }
        public string SentUserName { get; set; }
    }
}
