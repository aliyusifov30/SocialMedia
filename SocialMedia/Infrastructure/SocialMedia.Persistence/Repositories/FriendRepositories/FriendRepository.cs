using SocialMedia.Application.Repositories.FriendRepositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories.FriendRepositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}
