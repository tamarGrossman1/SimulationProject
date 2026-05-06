using BL.Api;
using BL.Models;
using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLillustrationViewPointService: IblIllustrationViewPoint
    {
        Idal dal;

        public BLillustrationViewPointService(Idal dal)
        {
            this.dal = dal;
        }

        public BLillustrationViewPoint ConvertToBl(IllustrationViewPoint i)
        {
            return new() { IllustrationViewPointId = i.IllustrationViewPointId , Description = i.Description  };

        }
      
        public async Task<List<BLillustrationViewPoint>> GetAllIllustration()
        {
            List<BLillustrationViewPoint> lst = new();
            dal.illustrationViewPoint.Read().Result.ForEach(i => lst.Add(ConvertToBl(i)));
            return lst;
        }

        
    }
}
