using Auction.Domain.Entities;
using MBC.Core.DataAccess.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DataAccess.Configurations
{
    public class AspNetUsersConfiguration : BaseConfiguration<AspNetUsers>
    {
       public override void ConfigureEntity(EntityTypeBuilder<AspNetUsers> builder)
       {

       }
    }
}
