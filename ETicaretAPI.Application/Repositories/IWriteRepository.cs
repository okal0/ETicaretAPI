using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> list);

        Task<int> SaveAsync();
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        bool Remove(T model);
      

        // RemoveRange gerekirse eklenicek
    }
}
