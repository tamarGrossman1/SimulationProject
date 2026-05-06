using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblIllustrationViewPoint
    {
        Task<List<BLillustrationViewPoint>>  GetAllIllustration();

} }
