using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblRecommend
    {
        Task<List<BLrecommend>> GetAll();
        Task<bool> Hasorder(int custId); 
        Task<bool> Create(BLrecommend item);
    }
}
