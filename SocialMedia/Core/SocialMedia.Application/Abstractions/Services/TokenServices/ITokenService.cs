using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services.TokenServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
