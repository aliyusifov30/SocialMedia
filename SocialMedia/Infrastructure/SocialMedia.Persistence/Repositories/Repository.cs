using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Repositories;
using SocialMedia.Domain.Entities.Common;
using SocialMedia.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        public Repository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity); 
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task Remove(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public async Task UnActive(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
        }
    }
}
