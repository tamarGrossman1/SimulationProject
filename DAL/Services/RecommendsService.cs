using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class RecommendsService:Irecommends
    {  DbManager mydb;
        public RecommendsService(DbManager mydb) {
            this.mydb = mydb;
        }
      
       
       
        public void Create(Recommend item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    try
                    {
                        mydb.Recommends.Add(item);
                    }
                    catch
                    {
                        mydb.Recommends.Local.Remove(item);
                    }
                    mydb.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException?.Message ?? ex.Message);
                }
        }

        public void Delete(Recommend item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Recommends.Remove
                (mydb.Recommends.Where(x => x.RecommendId == item.RecommendId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        public async Task<List<Recommend>> Read() => mydb.Recommends.ToList<Recommend>();

        public void Update(Recommend item)
        {
            mydb.Update(item);
            mydb.SaveChanges();
        }
    }
}
