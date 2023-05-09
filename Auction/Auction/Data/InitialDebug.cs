using Auction.Application.Features.DataBaseInitialization;
using Auction.Domain.Entities;
using MBC.Core.Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Auction.WebApi.Data
{
    public static class InitialDebug
    {
        public static async Task FillDevelopmentInfo(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            var employeeRepository = serviceProvider.GetRequiredService<IGenericRepository<Employee>>();

            if (await employeeRepository.AsQueryable().AnyAsync())
            {
                return;
            }
            
            var isNeedDataRollback = await AddDataTest(serviceProvider);
            

            if (isNeedDataRollback)
            {
                throw new Exception("Произошла ошибка в создании тестовой БД");
            }

        }

        private static async Task<bool> AddDataTest(IServiceProvider serviceProvider)
        {
            var mediator = serviceProvider.GetRequiredService<IMediator>();

            return await mediator.Send(new DatabaseInitializationCommand());
        }
    }
}
