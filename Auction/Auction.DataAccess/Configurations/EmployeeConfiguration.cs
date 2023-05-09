using Auction.Domain.Entities;
using MBC.Core.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.DataAccess.Configurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.HasOne(s => s.AspNetUser)
                .WithOne(g => g.Employee)
                .HasForeignKey<Employee>(s => s.AspNetUserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
