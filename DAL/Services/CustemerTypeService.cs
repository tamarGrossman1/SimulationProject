using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CustemerTypeService: IcustomerType
    {
        DbManager mydb;
        public CustemerTypeService(DbManager mydb) {
            this.mydb = mydb;
        }
        public void Create(CustemerType item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    mydb.CustemerTypes.Add(item);
                }
                catch
                {
                    throw new Exception("לא ניתן להכניס לקוח,נא בדוק את הפרטים ונסה שוב");
                }
        }

        public void Delete(CustemerType item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.CustemerTypes.Remove
                (mydb.CustemerTypes.Where(x => x.CustomerTypeId == item.CustomerTypeId).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }


        public  async Task<List<CustemerType>> Read() => mydb.CustemerTypes.ToList<CustemerType>();

        public void Update(CustemerType item)
        {
            mydb.Update(item);
            mydb.SaveChanges();
        }
    }
}
