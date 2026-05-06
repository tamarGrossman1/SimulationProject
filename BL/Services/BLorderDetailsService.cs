/*using BL.Api;
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
    public class BLorderDetailsService:IblOrderDetails
    {
        Idal dal;

        public BLorderDetailsService(Idal dal)
        {
            this.dal = dal;
        }
        public OrderD convertToDal(BLorderDetails o)
        {
            return new OrderDetail() { OrderDetailsId = o.OrderDetailsId, OrderId = o.OrderId, DealId = o.DealId,OrderFinishDate =o.OrderFinishDate,Status = o.Status};
        }

        public BLorderDetails ConvertToBl(Order o)
        {
            return new() { OrderDetailsId = o.OrderDetailsId, OrderId = o.OrderId, DealId = o.OrderId, Status = o.Status ,OrderFinishDate = o.OrderFinishDate  };
        }


        public async Task<List<BLorderDetails>> GetAll()
        {
            List<BLorderDetails> lst = new List<BLorderDetails>();
            dal.orderDetails.Read().Result.ForEach(o => lst.Add(ConvertToBl(o)));
            return lst;
        }

        public bool Search(BLorderDetails item)
        {
            foreach (BLorderDetails orderDetails in GetAll().Result)
            {
                if (orderDetails.OrderDetailsId == item.OrderDetailsId) return true;

                else return false;
            }
            return false;
        }
        
        public async Task<BLorderDetails> GetOrderById(int Deal)
        { 
            var list = await dal.orderDetails.Read();
            var order = list.Find(o =>
            {
               bool v = o.OrderId == Deal;
                return v;
            });

            if (order == null)
                return null;

            return ConvertToBl(order);
        }

        public bool Create(BLorderDetails item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (GetOrderById(item.OrderId) == null)
            {
                dal.orderDetails.Create(convertToDal(item));
                return true;
            }

            return false;
        }
        public bool Update(BLorderDetails item)
        {
            if (item == null) throw new ArgumentNullException("item");
            dal.orderDetails.Update(convertToDal(item));
            return true;
        }

    }
}*/
