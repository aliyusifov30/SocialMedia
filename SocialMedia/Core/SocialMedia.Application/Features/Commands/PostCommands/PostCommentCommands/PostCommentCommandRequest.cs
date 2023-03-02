using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCommentCommands
{
    public class PostCommentCommandRequest : IRequest<PostCommentCommandResponse>
    {
        public string? UserName { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

    }
}
