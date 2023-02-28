using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application.Abstractions.Services.TokenServices;
using SocialMedia.Application.DTOs.TokenDTOs;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Concretes.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenOptionDto _options;
        public TokenService(UserManager<AppUser> userManager, IOptions<TokenOptionDto> options)
        {
            _userManager = userManager;
            _options = options.Value;
        }

        public async Task<string> CreateToken(AppUser user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.NameIdentifier,user.Id),
            //    new Claim(ClaimTypes.Name, user.UserName),
            //};
            //claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            //string keyStr = _options.SecretKey;

            //SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyStr));
            //SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //JwtSecurityToken token = new JwtSecurityToken
            //    (
            //        claims: claims,
            //        expires: DateTime.UtcNow.AddDays(1),
            //        signingCredentials: credentials,
            //        issuer: _options.Issuer,
            //        audience: _options.Audience
            //    );

            //var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName)
                //todo you must add RoleClaims - i wrote this
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                    audience: _options.Audience,
                    issuer: _options.Issuer,
                    signingCredentials: signingCredentials,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return tokenStr;
        }
    }
}
