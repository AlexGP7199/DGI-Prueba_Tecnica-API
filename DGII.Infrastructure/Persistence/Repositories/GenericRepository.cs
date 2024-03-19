using DGII.Domain.Base;
using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DgiiPruebaTContext _appDbContext;
        protected readonly DbSet<T> _entity;
        public GenericRepository(DgiiPruebaTContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entity = _appDbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity.AsNoTracking().FirstOrDefaultAsync(x=> x.Id.Equals(id));
            return getById;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            await _appDbContext.AddAsync(entity);
            var recordsAffected = await _appDbContext.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            _appDbContext.Update(entity);
            var recordAffected = await _appDbContext.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _appDbContext.Remove(entity);

            var recordAffected = await _appDbContext.SaveChangesAsync();
            return recordAffected > 0;
        }
    }
}
