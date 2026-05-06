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
    public class BLorderService : IblOrder
    {
        Idal dal;

        public BLorderService(Idal dal)
        {
            this.dal = dal;
        }

        public Order convertToDal(BLorder o)
        {
            var x = new Order()
            {
                OrderId = o.OrderId,
                DealId = o.DealId,
                OrderFinishDate = o.OrderFinishDate,
                Status = o.Status,
                Meters = o.Meters,
                Budget = o.Budget,
                CustId = o.CustId,
                OrderDate = o.OrderDate,
                ViewPointId= o.ViewPointId,
               // ViewPoint = new IllustrationViewPoint() { IllustrationViewPointId = o.ViewPointId }
            };


            return x;
        }

        public BLorder ConvertToBl(Order o)
        {
             var x=new BLorder () { 
                OrderId = o.OrderId,
                DealId = o.DealId,
                OrderFinishDate = o.OrderFinishDate , 
                Status = o.Status,
                Meters = o.Meters ,
                Budget = o.Budget ,
                OrderDate =o.OrderDate ,                
                CustId = o.CustId ,
                ViewPointId = o.ViewPointId,
                DealName = dal.deal.Read().Result.Find(x => x.DealId == o.DealId).DealDescription,
                CustName = dal.client.Read().Result.Find(x => x.CustomersId == o.CustId).CompNameCustName
                
            }      ;
            return x;

        }
        public async Task<BLclient> GetClientById(int custId)
        {
            var list = await dal.client.Read();
            var client = list.Find(c => c.CustomersId == custId);

            if (client == null)
                return null;

            return ConvertToBl(client);
        }
        public BLclient ConvertToBl(Customer c)
        {
            return new() { CustomersId = c.CustomersId, Phone = c.Phone, CompNameCustName = c.CompNameCustName, Mail = c.Mail, ConnectPerson = c.ConnectPerson, CustomerType = c.CustomerType };
        }

        public async Task<List<BLorder>> GetAllorders()
        {
            List<BLorder> lst = new();
            dal.order.Read().Result.ForEach(c => lst.Add(ConvertToBl(c)));
            return lst;
        }
        //public async Task<BLorder> GetOrderById(int OrderId)
        //{
        //    var list = await dal.order.Read();
        //    var order = list.Find(c => c.OrderId == OrderId);

        //    if (order == null)
        //        return null;

        //    return ConvertToBl(order);
        //}
        public Customer GetCustomerByOrderId(int orderId)
        {
            return dal.order.GetCustomerByOrderId(orderId);
        }
        public bool Update(BLorder item)
        {
            if (item == null) throw new ArgumentNullException("item");
            dal.order.Update(convertToDal(item));
            return true;
        }
        public bool Create(BLorder item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
            {
                var x = convertToDal(item);
                dal.order.Create(x);
                return true;
            }

        }


    }
}


