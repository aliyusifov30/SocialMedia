using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.PostServices;
using SocialMedia.Application.Repositories.PostLikeRepositories;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostUnlikeCommands
{
    public class PostUnlikeCommandHandler : IRequestHandler<PostUnlikeCommandRequest, PostUnlikeCommandResponse>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly UserManager<AppUser> _userManager;
        public PostUnlikeCommandHandler(IPostLikeRepository postLikeRepository, UserManager<AppUser> userManager)
        {
            _postLikeRepository = postLikeRepository;
            _userManager = userManager;
        }

        public async Task<PostUnlikeCommandResponse> Handle(PostUnlikeCommandRequest request, CancellationToken cancellationToken)
        {

            var appUser = await _userManager.FindByNameAsync(request.UserName);

            var postLike = await _postLikeRepository.GetAsync(x => x.PostId == request.PostId && x.FromUserId == appUser.Id);

            await _postLikeRepository.Remove(x=>x.Id == postLike.Id);
            await _postLikeRepository.CommitAsync();
            return new PostUnlikeCommandResponse();
        }
    }
}
