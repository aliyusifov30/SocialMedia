using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialMedia.Persistence.Configurations;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SocialMediaContext>
    {
        public SocialMediaContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SocialMediaContext> builder = new();
            builder.UseSqlServer(ServiceConfiguration.GetConnectionString);
            return new SocialMediaContext(builder.Options);
        }
    }
}
