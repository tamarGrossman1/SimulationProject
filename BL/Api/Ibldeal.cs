using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface Ibldeal
    {
        Task<List<BLdeal>> GetAllDeals();
        bool Create(BLdeal item);
        bool Update(BLdeal item);


    }
}
