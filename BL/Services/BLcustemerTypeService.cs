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
    public class BLcustemerTypeService: IblCustomerType
    {
        Idal dal;
        public BLcustemerTypeService(Idal dal) {
            this.dal = dal;
        }
        public BLcustomerType ConvertToBl(CustemerType t)
        {
            return new() { CustomerTypeId = t.CustomerTypeId, CustomerType = t.CustomerType };
        }
        public async  Task<List<BLcustomerType>> GetAllTypes()
        {
            List<BLcustomerType> lst = new();
            dal.customerType.Read().Result.ForEach(c => lst.Add(ConvertToBl(c)));
            return lst;
        }

    }
}
