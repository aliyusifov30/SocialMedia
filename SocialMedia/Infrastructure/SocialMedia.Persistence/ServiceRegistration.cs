using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistence.Configurations;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<SocialMediaContext>(opt => { opt.UseSqlServer(ServiceConfiguration.GetConnectionString); })
                .AddIdentity<AppUser, IdentityRole>(opt =>
                {
                    opt.User.RequireUniqueEmail = false;

                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 5;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                }).AddEntityFrameworkStores<SocialMediaContext>();
        }

    }
}
