using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCommentRemoveCommands
{
    public class PostCommentRemoveCommandRequest : IRequest<PostCommentRemoveCommandResponse>
    {
        public string? UserName { get; set; }
        public int CommentId { get; set; }
    }
}
