using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblProject
    {
        Task<List<BLproject>> GetAllProjects();
        bool Create(BLproject item);
        bool Update(BLproject item);
    }
}
