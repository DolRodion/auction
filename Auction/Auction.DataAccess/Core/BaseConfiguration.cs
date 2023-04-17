using MBC.Core.Domain.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBC.Core.DataAccess.Core
{
    /// <summary>
    /// Конфигурация базовой сущности
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Конфигруация базовой сущности
        /// </summary>
        /// <param name="builder">builder</param>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);

            ConfigureEntity(builder);
        }

        /// <summary>
        /// Конфигурия сущности
        /// </summary>
        /// <param name="builder">builder</param>
        public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}