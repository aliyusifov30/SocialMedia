using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.PostServices;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostArchiveCommands
{
    public class PostArchiveCommandHandler : IRequestHandler<PostArchiveCommandRequest, PostArchiveCommandResponse>
    {

        private readonly IPostRepository _postRepository;
        private readonly IPostService _postService;
        public PostArchiveCommandHandler(IPostRepository postRepository, IPostService postService)
        {
            _postRepository = postRepository;
            _postService = postService;
        }

        public async Task<PostArchiveCommandResponse> Handle(PostArchiveCommandRequest request, CancellationToken cancellationToken)
        {

            var post = _postService.GetPost(request.UserName, request.PostId);

            if (post == null) throw new Exception("You can't archive this post"); 

            await _postRepository.UnActive(request.PostId);
            await _postRepository.CommitAsync();
            return new PostArchiveCommandResponse();
        }
    }
}
