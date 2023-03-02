using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Repositories.CommentRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostCommands.PostCommentRemoveCommands
{
    public class PostCommentRemoveCommandHandler : IRequestHandler<PostCommentRemoveCommandRequest, PostCommentRemoveCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<AppUser> _userManager;

        public PostCommentRemoveCommandHandler(ICommentRepository commentRepository, UserManager<AppUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<PostCommentRemoveCommandResponse> Handle(PostCommentRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);
            if (appUser == null) throw new Exception("Couldn't find user");
            
            var comment = await _commentRepository.GetAsync(x => x.Id == request.CommentId);
            if (comment == null) throw new Exception("Couldn't find comment");

            await _commentRepository.Remove(x=>x.Id == comment.Id);
            await _commentRepository.CommitAsync();

            return new PostCommentRemoveCommandResponse();
        }
    }
}
