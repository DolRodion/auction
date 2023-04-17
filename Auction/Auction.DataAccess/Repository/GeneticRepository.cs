using MBC.Core.DataAccess.Core;
using MBC.Core.Domain.Contracts;
using MBC.Core.Domain.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MBC.Core.DataAccess.Repository
{
    public class GenericRepository<T> :  IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid? id)
        {
            T entity = await GetByIdAsync(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        private async Task<T> GetByIdAsync(Guid? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}