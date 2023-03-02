using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostDeleteCommands
{
    public class PostDeleteCommandRequest : IRequest<PostDeleteCommandResponse>
    {
        public string? UserName { get; set; }
        public int PostId { get; set; }
    }
}
