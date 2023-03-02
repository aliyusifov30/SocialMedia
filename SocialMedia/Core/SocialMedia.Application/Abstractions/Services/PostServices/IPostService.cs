using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services.PostServices
{
    public interface IPostService
    {

        Task<Post> GetPost(string userName,int postId);

    }
}
