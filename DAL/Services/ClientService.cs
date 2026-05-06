using DAL.Appi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ClientService : Iclient
    {
        DbManager mydb;
        public ClientService(DbManager mydb)
        {
            this.mydb = mydb;
        }

       

        public void Create(Customer item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    try { 
                    mydb.Customers.Add(item);}
                    catch
                    {
                        mydb.Customers.Local.Remove(item);
                    }
                    mydb.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException?.Message ?? ex.Message);
                }
        }

        public void Delete(Customer item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Customers.Remove
                (mydb.Customers.Where(x => x.CustomersId == item.CustomersId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        //  public async Task<List<Customer>> Read() => mydb.Customers.ToList();//<Customer>();
        public async Task<List<Customer>> Read() { return await mydb.Customers.ToListAsync(); }//<Customer>();

        public void Update(Customer item)
        {
            var a = mydb.Customers.Where(x => x.CustomersId == item.CustomersId).FirstOrDefault();
            if (a != null) {
                a.CompNameCustName = item.CompNameCustName;
                a.Phone = item.Phone;
                a.Mail = item.Mail;
                mydb.Update(a);
                mydb.SaveChanges(); }
            else { 
                throw new Exception("לא נמצא הפריט לעדכון"); }
        }
        
  
        
}
}
