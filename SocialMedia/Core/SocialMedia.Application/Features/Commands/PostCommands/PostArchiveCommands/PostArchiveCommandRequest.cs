using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostArchiveCommands
{
    public class PostArchiveCommandRequest : IRequest<PostArchiveCommandResponse>
    {
        public string? UserName { get; set; }
        public int PostId { get; set; }
    }
}
