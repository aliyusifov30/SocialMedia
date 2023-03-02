using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services.UserServices
{
    public interface IUserService
    {
        Task AddFriend(string fromUsernName, string toUserName);
        Task AcceptFriend(string accept, string sent);
    }
}
