using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.DataBaseInitialization
{
    public class DatabaseInitializationCommand : IRequest<bool> 
    {
    }
}
