using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Repositories;
using SocialMedia.Domain.Entities.Common;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories
{
    public class RepositoryBaseEntity<T> : Repository<T>,IRepositoryBaseEntity<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;

        public RepositoryBaseEntity(SocialMediaContext context):base(context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UnActive(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
        }
    }
}
