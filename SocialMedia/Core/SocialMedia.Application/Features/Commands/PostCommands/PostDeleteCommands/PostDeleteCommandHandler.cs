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

namespace SocialMedia.Application.Features.Commands.PostCommands.PostDeleteCommands
{
    public class PostDeleteCommandHandler : IRequestHandler<PostDeleteCommandRequest, PostDeleteCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostService _postService;
        public PostDeleteCommandHandler(IPostRepository postRepository, IPostService postService)
        {
            _postRepository = postRepository;
            _postService = postService;
        }

        public async Task<PostDeleteCommandResponse> Handle(PostDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var post = await _postService.GetPost(request.UserName, request.PostId);

            if (post == null) throw new Exception("You can't remove this post!");

            await _postRepository.Remove(x => x.Id == request.PostId);
            await _postRepository.CommitAsync();

            return new PostDeleteCommandResponse() 
            {
                
            };
        }
    }
}
