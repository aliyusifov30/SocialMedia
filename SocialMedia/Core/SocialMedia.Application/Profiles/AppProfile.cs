using AutoMapper;
using SocialMedia.Application.DTOs.AccountDTOs;
using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Application.Features.Commands.AccountCommands.AccountLoginCommands;
using SocialMedia.Application.Features.Commands.AccountCommands.AccountRegiterCommands;
using SocialMedia.Application.Features.Commands.PostCommands.PostCreateCommands;
using SocialMedia.Application.Features.Queries.PostGetQueries;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Profiles
{
    public class AppProfile : Profile
    {

        public AppProfile()
        {
            CreateMap<AccountRegisterCommandRequest,AccountRegisterDto>();
            CreateMap<AccountLoginCommandRequest, AccountLoginDto>();
            CreateMap<PostCreateCommandRequest, Post>();

            CreateMap<PostCreateCommandRequest, PostCreateCommandResponse>()
                .ForMember(dest=>dest.Content,opt=>opt.MapFrom(c=>c.Content.FileName));
            CreateMap<Post, PostGetQueryResponse>();

            CreateMap<Post, PostGetDto>();
        }

    }
}
