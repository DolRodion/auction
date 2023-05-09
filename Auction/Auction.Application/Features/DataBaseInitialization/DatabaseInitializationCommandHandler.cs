using Auction.Application.Features.Employees.InitAdminDefault;
using Auction.Application.Features.Employees.InitUserDefault;
using MBC.Core.DataAccess.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Application.Features.DataBaseInitialization
{
    public class DatabaseInitializationCommandHandler : IRequestHandler<DatabaseInitializationCommand, bool>
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly ApplicationDbContext _applicationDbContext;

        public DatabaseInitializationCommandHandler(IServiceProvider serviceProvider, ApplicationDbContext applicationDbContext)
        {
            _serviceProvider = serviceProvider;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DatabaseInitializationCommand query, CancellationToken cancellationToken)
        {
            using (var transaction = await _applicationDbContext.Database.BeginTransactionAsync())
            {
                var mediator = _serviceProvider.GetRequiredService<IMediator>();

                try
                {
                    await mediator.Send(new InitAdminDefaultCommand());
                    await mediator.Send(new InitUserDefaultCommand());

                    await transaction.CommitAsync();
                    return false;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return true;
                }
            }
        }
    }
}
