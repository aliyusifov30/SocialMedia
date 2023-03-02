using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.PostServices;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Concretes.Services.PostServices
{
    public class PostService : IPostService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IPostRepository _postRepository;

        public PostService(UserManager<AppUser> userManager, IPostRepository postRepository)
        {
            _userManager = userManager;
            _postRepository = postRepository;
        }

        public async Task<Post> GetPost(string userName, int postId)
        {

            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null) throw new Exception("Couldn't find user");

            return await _postRepository.GetAsync(x => x.Id == postId && x.AppUserId == appUser.Id);
        }
    }
}
