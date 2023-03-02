using SocialMedia.Application.Repositories.PostLikeRepositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories.PostLikeRepositories
{
    public class PostLikeRepository : Repository<PostLike>, IPostLikeRepository
    {
        public PostLikeRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}
