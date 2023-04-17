using MBC.Core.Domain.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MBC.Core.Domain.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Шаблонная функция добавления новых записей
        /// </summary>
        /// <param name="entity">Приниемая сущность</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// Шаблонная функция удаления записи(шаблон для сущности)
        /// </summary>
        Task DeleteAsync(Guid? id);

        /// <summary>
        /// Получение сущности с помощью AsQueryable
        /// </summary>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Запрос на Update
        /// </summary>
        Task SaveChangesAsync();
    }
}