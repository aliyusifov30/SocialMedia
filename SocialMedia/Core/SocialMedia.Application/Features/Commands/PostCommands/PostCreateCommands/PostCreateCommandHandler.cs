using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.LocalServices;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands
{
    public class PostCreateCommandHandler : IRequestHandler<PostCreateCommandRequest, PostCreateCommandResponse>
    {

        private readonly IPostRepository _postRepository;
        private readonly ILocalFileService _localFileService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public PostCreateCommandHandler(IPostRepository postRepository, ILocalFileService localFileService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _postRepository = postRepository;
            _localFileService = localFileService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<PostCreateCommandResponse> Handle(PostCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var content = _localFileService.Upload(request.Content, "/uploads/posts/");
            
            var appUser = await _userManager.FindByNameAsync(request.UserName);

            await _postRepository.AddAsync(new Post()
            {
                Content = content,
                AppUser = appUser,
                Title = request.Title
            });
            await _postRepository.CommitAsync();
           
            return _mapper.Map<PostCreateCommandResponse>(request);
        }
    }
}
