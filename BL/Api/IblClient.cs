
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblClient
    {
        bool Search(BLclient item);
        Task<List<BLclient>> GetAll();
        Task<bool> Create(BLclient item);
        //bool Create(BLclient item);
        bool Update (BLclient item);
        Task<BLclient> GetClientById(string Mail);
    }
}
