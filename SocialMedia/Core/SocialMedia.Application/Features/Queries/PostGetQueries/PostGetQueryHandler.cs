using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Repositories.FriendRepositories;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetQueries
{
    public class PostGetQueryHandler : IRequestHandler<PostGetQueryRequest, PostGetQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendRepository _friendRepository;
        public PostGetQueryHandler(IPostRepository postRepository, IMapper mapper, UserManager<AppUser> userManager, IFriendRepository friendRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _userManager = userManager;
            _friendRepository = friendRepository;
        }

        public async Task<PostGetQueryResponse> Handle(PostGetQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new AppUser();
            Post post = new Post();

            post = await _postRepository.GetAsync(x=>x.Id == request.Id,true, "AppUser");

            if (request.UserName != null)
                user = await _userManager.FindByNameAsync(request.UserName);

            if (!post.AppUser.IsPrivate)
            {
                post = await _postRepository.GetAsync(x => x.Id == request.Id && x.IsDeleted == false);
            }
            else
            {
                var friend = await _friendRepository.GetAsync(x => x.FromUserId == user.Id && x.ToUserId == post.AppUserId);
                if (friend == null || friend.IsFriend == false || request.UserName == null) throw new Exception("You can't see posts");
                
                post = await _postRepository.GetAsync(x => x.Id == request.Id && x.IsDeleted == false);
            }

            return _mapper.Map<PostGetQueryResponse>(post);
        } 
    }
}
