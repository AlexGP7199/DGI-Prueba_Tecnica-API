using DGII.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);
    }
}
