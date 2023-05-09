
using Auction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MBC.Core.DataAccess.Core
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// No param
        /// </summary>
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ConfigureBaseAuditEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


        /// <summary>
        /// Протоколирование запросов на изменение/создание данных
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Пользователь 
        /// </summary>
        public DbSet<Employee> Employee { get; set; }

        /// <summary>
        /// AspNetUsers
        /// </summary>
        public DbSet<AspNetUsers> Agreement { get; set; }
    }
}

