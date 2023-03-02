using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Repositories.PostLikeRepositories;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostLikeCommands
{
    public class PostLikeCommandHandler : IRequestHandler<PostLikeCommandRequest, PostLikeCommandResponse>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<AppUser> _userManager;

        public PostLikeCommandHandler(IPostLikeRepository postLikeRepository, UserManager<AppUser> userManager, IPostRepository postRepository)
        {
            _postLikeRepository = postLikeRepository;
            _userManager = userManager;
            _postRepository = postRepository;
        }

        public async Task<PostLikeCommandResponse> Handle(PostLikeCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var post = await _postRepository.GetAsync(x => x.Id == request.PostId);

            if (post == null) throw new Exception("Couldn't find post");

            await _postLikeRepository.AddAsync(new PostLike
            {
                PostId = post.Id,
                FromUser = user,
            });

            await _postLikeRepository.CommitAsync();

            return new PostLikeCommandResponse()
            {

            };
        }
    }
}
