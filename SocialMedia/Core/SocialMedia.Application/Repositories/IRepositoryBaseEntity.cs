using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Repositories
{
    public interface IRepositoryBaseEntity<T> where T : class
    {
        Task UnActive(int id);
        Task<T> GetByIdAsync(int id, bool tracking = true);
    }
}
