using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.PostGetAllQueries
{
    public class PostGetAllQueryHandler : IRequestHandler<PostGetAllQueryRequest, PostGetAllQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public PostGetAllQueryHandler(IPostRepository postRepository, UserManager<AppUser> userManager, IMapper mapper)
        {
            _postRepository = postRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PostGetAllQueryResponse> Handle(PostGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var posts = await _postRepository.GetAllAsync(x => x.IsDeleted == false && x.AppUserId == user.Id);

            return new PostGetAllQueryResponse()
            {
                PostGetDtos = _mapper.Map<ICollection<PostGetDto>>(posts)
            };
        }
    }
}
