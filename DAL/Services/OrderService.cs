using DAL.Appi;
using DAL.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class OrderService : Iorder
    {
        DbManager mydb;
        public OrderService(DbManager mydb)
        {
            this.mydb = mydb;
        }
        public void Create(Order item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    try
                    {
                       mydb.Orders.Add(item); 
                    }
                    catch {
                        mydb.Orders.Local.Remove(item);
                    }
                   mydb.SaveChanges(); }
                
                 
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException?.Message ?? ex.Message);
                }
        }
        public Customer GetCustomerByOrderId(int orderId)
        {
            return mydb.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => o.Cust)
                .FirstOrDefault()??new();
        }

        public void Delete(Order item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Orders.Remove
                (mydb.Orders.Where(x => x.OrderId == item.OrderId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        //public async Task<List<Order>> Read() => mydb.Orders.ToList<Order>();
        

public async Task<List<Order>> Read()
    {
        return await mydb.Orders.ToListAsync();
    }
    public void Update(Order item)
        {
            var a = mydb.Orders.Where(x => x.OrderId == item.OrderId).FirstOrDefault();
            if (a != null)
            {

                a.Status = item.Status;
                mydb.Update(a);
                mydb.SaveChanges();
            }
            else
            {
                throw new Exception("לא נמצא הפריט לעדכון");
            }
        }
    }
}
