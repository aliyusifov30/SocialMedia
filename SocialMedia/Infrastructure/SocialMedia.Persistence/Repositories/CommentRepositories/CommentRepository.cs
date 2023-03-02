using SocialMedia.Application.Repositories.CommentRepositories;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}
