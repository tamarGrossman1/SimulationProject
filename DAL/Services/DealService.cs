using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DealService : Ideal
    {
        DbManager mydb;
        public DealService(DbManager mydb)
        {
            this.mydb = mydb;
        }
        public void Create(Deal item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    mydb.Deals.Add(item);
                }
                catch
                {
                    throw new Exception("לא ניתן להכניס לקוח,נא בדוק את הפרטים ונסה שוב");
                }
        }

        public void Delete(Deal item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Deals.Remove
                (mydb.Deals.Where(x => x.DealId == item.DealId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        public async Task<List<Deal>> Read() => mydb.Deals.ToList<Deal>();


        public void Update(Deal item)
        {
            var a = mydb.Deals.Where(x => x.DealId == item.DealId).FirstOrDefault();
            if (a != null)
            {
                
                a.DealDescription = item.DealDescription;
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

  
        
