using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblOrder
    {  
        Task<List<BLorder>> GetAllorders();
        bool Create(BLorder item);
        bool Update(BLorder item);
        Customer GetCustomerByOrderId(int orderId);

    }
}


