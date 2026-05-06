using BL.Api;
using BL.Models;
using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class BLrecommendsService:IblRecommend
    {  Idal dal;
        public BLrecommendsService(Idal dal) {
            this.dal = dal;
        }
        public async Task<List<BLrecommend>> GetAll()
        {
            List<BLrecommend> lst = new List<BLrecommend>();
            dal.Recommend.Read().Result.ForEach(c => lst.Add(ConvertToBl(c)));
            return lst;
        }
        public Recommend convertToDal(BLrecommend b)
        {
            return new Recommend() { RecommendId = b.RecommendId  ,CustomerId = b.CustomerId,DealId = b.DealId, RecDescription = b.RecDescription};
        }

        public BLrecommend ConvertToBl(Recommend c)
        {
            return new() { 
                RecommendId = c.RecommendId,
                CustomerId =c.CustomerId,
                CustomerName=dal.client.Read().Result.Find(x=> x.CustomersId==c.CustomerId).CompNameCustName,
                DealId = c.DealId,
                DealName= dal.deal.Read().Result.Find(x => x.DealId == c.DealId).
                DealDescription, 
                RecDescription = c.RecDescription };
        }
        public async Task<bool> Create(BLrecommend item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var clienthasorder = await Hasorder(item.CustomerId);

            if (clienthasorder == null)
            {
                dal.Recommend.Create(convertToDal(item));
                return true;
            }

            return false;
        }

        public async Task<bool> Hasorder(int custId)
        {
            var list = await dal.order.Read();
            var client = list.Find(c => c.CustId == custId);

            if (client == null)
                return false;

              return true;
        }
    }
}
