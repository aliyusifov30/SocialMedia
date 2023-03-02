using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services.UserServices;
using SocialMedia.Application.Repositories.FriendRepositories;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Concretes.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendRepository _friendRepository;
        public UserService(UserManager<AppUser> userManager, IFriendRepository friendRepository)
        {
            _userManager = userManager;
            _friendRepository = friendRepository;
        }

        public async Task AcceptFriend(string accept, string sent)
        {
            AppUser sentUser = await _userManager.FindByNameAsync(sent);
            AppUser acceptUser = await _userManager.FindByNameAsync(accept);

            if (acceptUser == null || sentUser == null) throw new Exception("Couldn't find user");

            var friend = await _friendRepository.GetAsync(x => x.ToUserId == acceptUser.Id && x.FromUserId == sentUser.Id);

            if (friend == null) throw new Exception("Couldn't find request");

            friend.IsFriend = true;
            await _friendRepository.CommitAsync();
        }

        public async Task AddFriend(string fromUsernName, string toUserName)
        {
            var fromUser = await _userManager.FindByNameAsync(fromUsernName);

            var toUser = await _userManager.FindByNameAsync(toUserName);
            if (toUser == null) throw new Exception("Couldn't found: " + toUserName);

            var checkFriend = await _friendRepository.GetAsync(x => x.ToUserId == toUser.Id && x.FromUserId == fromUser.Id);
            if (checkFriend != null) throw new Exception("You sent request");
            
            if(toUser.IsPrivate == false)
            {
                await _friendRepository.AddAsync(new Friend()
                {
                    FromUser = fromUser,
                    ToUser = toUser,
                    IsFriend = true
                });
            }
            else
            {
                await _friendRepository.AddAsync(new Friend()
                {
                    FromUser = fromUser,
                    ToUser = toUser,
                });
            }
            await _friendRepository.CommitAsync();
        }
    }
}
