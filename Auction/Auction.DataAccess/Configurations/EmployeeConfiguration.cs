using MBC.Core.DataAccess.Core;
using MBC.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.DataAccess.Configurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Employee> modelBuilder)
        {

        }
    }
}
