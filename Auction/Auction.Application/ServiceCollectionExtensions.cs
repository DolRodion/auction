using MBC.Core.DataAccess.Repository;
using MBC.Core.Domain.Contracts;
using MBC.Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Auction.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();

            return services;
        }
    }
}
