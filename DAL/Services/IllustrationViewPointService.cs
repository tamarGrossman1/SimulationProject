using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class IllustrationViewPointService: IillustrationViewPoint
    {
        DbManager mydb;
        public IllustrationViewPointService(DbManager mydb)
        {
            this.mydb = mydb;
        }
        public void Create(IllustrationViewPoint item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    mydb.IllustrationViewPoints.Add(item);
                }
                catch
                {
                    throw new Exception("לא ניתן להכניס לקוח,נא בדוק את הפרטים ונסה שוב");
                }
        }

        public void Delete(IllustrationViewPoint item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.IllustrationViewPoints.Remove
                (mydb.IllustrationViewPoints.Where(x => x.IllustrationViewPointId == item.IllustrationViewPointId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        public async Task<List<IllustrationViewPoint>> Read() => mydb.IllustrationViewPoints.ToList();

        public void Update(IllustrationViewPoint item)
        {
            mydb.Update(item);
            mydb.SaveChanges();
        }

    }
}
