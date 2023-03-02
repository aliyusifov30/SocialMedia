using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Repositories.CommentRepositories;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCommentCommands
{
    public class PostCommentCommandHandler : IRequestHandler<PostCommentCommandRequest, PostCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPostRepository _postRepository;
        public PostCommentCommandHandler(ICommentRepository commentRepository, UserManager<AppUser> userManager, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
            _postRepository = postRepository;
        }

        public async Task<PostCommentCommandResponse> Handle(PostCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);

            var post = await _postRepository.GetAsync(x=>x.Id == request.PostId);
            if (post == null) throw new Exception("Couldn't find post");

            await _commentRepository.AddAsync(new Comment()
            {
                PostId = post.Id,
                AppUserId = appUser.Id,
                Content = request.Content
            });
            await _commentRepository.CommitAsync();
            return new PostCommentCommandResponse();
        }
    }
}
