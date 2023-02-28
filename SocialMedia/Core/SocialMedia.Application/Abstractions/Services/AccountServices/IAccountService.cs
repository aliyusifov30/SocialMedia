using SocialMedia.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services.AccountServices
{
    public interface IAccountService
    {
        Task Register(AccountRegisterDto accountRegisterDto);
        Task<string> Login(AccountLoginDto loginDto);
    }
}
