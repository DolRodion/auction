using Auction.Application.Common.Responces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Application.Features.Test
{
    public class CreateCameraQueryHandler:  IRequestHandler<CreateCameraQuery, Response>
    {
        public async Task<Response> Handle(CreateCameraQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return new Response();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
