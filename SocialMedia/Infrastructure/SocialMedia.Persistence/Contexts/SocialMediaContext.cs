using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Contexts
{
    public class SocialMediaContext : IdentityDbContext
    {

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options):base(options)
        {

        }
        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
