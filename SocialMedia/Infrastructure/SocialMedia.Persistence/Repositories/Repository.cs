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
    public class Repository<T> : IRepository<T> where T : class
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
            var response = await _context.Set<T>().FirstOrDefaultAsync(expression);
            return response;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracking = true, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            var response = await query.FirstOrDefaultAsync(expression);
            return response;
        }
        public async Task Remove(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);
            _context.Set<T>().Remove(entity);
        }
    }
}
