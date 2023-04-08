using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Common.Responces
{
    public interface IResponse
    {
        /// <summary>
        /// Выполнен успешно
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Ошибки выполнения запроса
        /// </summary>
        string Errors { get; set; }
    }
}
