using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Services
{
    public interface ICartService
    {
        Task<int> GetTotal(string cartId);
    }
}
