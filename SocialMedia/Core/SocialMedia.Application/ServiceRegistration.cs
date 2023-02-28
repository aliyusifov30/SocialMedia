using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<AppProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
