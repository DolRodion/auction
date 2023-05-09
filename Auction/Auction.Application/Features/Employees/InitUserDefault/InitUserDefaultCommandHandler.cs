using Auction.Application.Common.Responces;
using Auction.DataAccess.Core;
using Auction.Domain.Entities;
using MBC.Core.Domain.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Application.Features.Employees.InitUserDefault
{
    public class InitUserDefaultCommandHandler : IRequestHandler<InitUserDefaultCommand, Response>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<AspNetUsers> _aspNetUsersRepository;

        public InitUserDefaultCommandHandler(IGenericRepository<Employee> employeeRepository, IGenericRepository<AspNetUsers> aspNetUsersRepository)
        {
            _employeeRepository = employeeRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
        }

        public async Task<Response> Handle(InitUserDefaultCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var aspNetUserId = Guid.NewGuid();

                var aspNetUser = new AspNetUsers()
                {
                    Id = aspNetUserId,
                    PasswordHash = EncryptionProvider.HashPassword("qwerty"),
                    Email = "sarancha@gmail.com",
                    AccessFailedCount = 0,
                    PhoneNumber = "+79787158321",
                    Login = "Vetalya",
                    LockoutEnabled = true,
                    LockoutEnd = null
                };

                await _aspNetUsersRepository.InsertAsync(aspNetUser);

                await _aspNetUsersRepository.SaveChangesAsync();

                var employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Vetalya",
                    MiddleName = "Vezelev",
                    LastName = "Albertovich",
                    IsAdmin = true,
                    AspNetUserId = aspNetUserId,
                };

                await _employeeRepository.InsertAsync(employee);

                await _employeeRepository.SaveChangesAsync();


                return Response.GetSuccessResponse();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
