using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using SocialMedia.Application.Abstractions.Services.AccountServices;
using SocialMedia.Application.Abstractions.Services.TokenServices;
using SocialMedia.Application.DTOs.AccountDTOs;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Concretes.Services.AccountServices
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(AccountLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null) throw new Exception("Something goes wrong");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) throw new Exception("Something goes wrong");

            var token = await _tokenService.CreateToken(user);

            return token;
        }

        public async Task Register(AccountRegisterDto accountRegisterDto)
        {
            AppUser appUser = await _userManager.FindByNameAsync(accountRegisterDto.UserName);

            if (appUser != null) throw new Exception("Bele bir hesab var");

            if (!accountRegisterDto.Password.Equals(accountRegisterDto.RePassword)) throw new Exception("Parollar yanlisdir");

            appUser = new AppUser
            {
                Email = accountRegisterDto.Email,
                UserName = accountRegisterDto.UserName,
            };

            var result = await _userManager.CreateAsync(appUser, accountRegisterDto.Password);

            foreach (var error in result.Errors)
            {
                throw new Exception(error.Description);
            }

            await _userManager.AddToRoleAsync(appUser, "Member");
            //await _userManager.AddToRoleAsync(appUser, accountRegisterDto.AppUserRoleEnum.ToString());
        }
    }
}
