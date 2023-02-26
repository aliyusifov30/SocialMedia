using MediatR;
using SocialMedia.Application.Abstractions.Services.LocalServices;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands
{
    public class PostCreateCommandHandler : IRequestHandler<PostCreateCommandRequest, PostCreateCommandResponse>
    {

        private readonly IPostRepository _postRepository;
        private readonly ILocalFileService _localFileService;
        public PostCreateCommandHandler(IPostRepository postRepository, ILocalFileService localFileService)
        {
            _postRepository = postRepository;
            _localFileService = localFileService;
        }
        public async Task<PostCreateCommandResponse> Handle(PostCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var content = _localFileService.Upload(request.Content, "/uploads/posts/");
            await _postRepository.AddAsync(new Post()
            {
                Title = request.Title,
                Content = content
            });
            await _postRepository.CommitAsync();

            return new PostCreateCommandResponse()
            {
                Title = request.Title,
                Content = content
            };
        }
    }
}
