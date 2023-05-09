using Auction.Application.Common.Responces;
using MBC.Core.Domain.Contracts;
using MediatR;
using Auction.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System;
using Auction.DataAccess.Core;

namespace Auction.Application.Features.Employees.InitAdminDefault
{
    public class InitAdminDefaultCommandHandler : IRequestHandler<InitAdminDefaultCommand, Response>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<AspNetUsers> _aspNetUsersRepository;

        public InitAdminDefaultCommandHandler(IGenericRepository<Employee> employeeRepository, IGenericRepository<AspNetUsers> aspNetUsersRepository)
        {
            _employeeRepository = employeeRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
        }

        public async Task<Response> Handle(InitAdminDefaultCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var aspNetUserId = Guid.NewGuid();

                var aspNetUser = new AspNetUsers()
                {
                    Id = aspNetUserId,
                    PasswordHash = EncryptionProvider.HashPassword("qwerty"),
                    Email = "dolrodion@gmail.com",
                    AccessFailedCount = 0,
                    PhoneNumber = "+79787158435",
                    Login = "Rodion",
                    LockoutEnabled = true,
                    LockoutEnd = null
                };

                await _aspNetUsersRepository.InsertAsync(aspNetUser);
 
                await _aspNetUsersRepository.SaveChangesAsync();

                var employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Rodion",
                    MiddleName = "Dolgopolov",
                    LastName = "Igorevich",
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
