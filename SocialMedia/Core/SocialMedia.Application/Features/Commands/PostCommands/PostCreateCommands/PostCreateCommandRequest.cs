using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands
{
    public class PostCreateCommandRequest : IRequest<PostCreateCommandResponse>
    {
        public string Title { get; set; }
        public IFormFile Content { get; set; }
        public string? UserName { get; set; }

    }
}
