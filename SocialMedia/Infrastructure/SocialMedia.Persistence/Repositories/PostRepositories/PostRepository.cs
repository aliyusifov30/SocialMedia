using SocialMedia.Application.Repositories;
using SocialMedia.Application.Repositories.PostRepositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories.PostRepositories
{
    public class PostRepository : RepositoryBaseEntity<Post>, IPostRepository
    {
        public PostRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}
