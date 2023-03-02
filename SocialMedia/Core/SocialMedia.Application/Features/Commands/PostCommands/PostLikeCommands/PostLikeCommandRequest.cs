using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostLikeCommands
{
    public class PostLikeCommandRequest : IRequest<PostLikeCommandResponse>
    {
        public int PostId { get; set; }
        public string? UserName { get; set; }
    }
}
