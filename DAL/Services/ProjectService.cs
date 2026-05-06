using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ProjectService : Iproject
    {
        DbManager mydb;
       public ProjectService(DbManager mydb)
        {
            this.mydb = mydb;
        }
        public void Create(Project item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
                try
                {
                    mydb.Projects.Add(item);
                }
                catch
                {
                    throw new Exception("לא ניתן להכניס לקוח,נא בדוק את הפרטים ונסה שוב");
                }
        }
        public void Delete(Project item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Projects.Remove
                (mydb.Projects.Where(x => x.Id == item.Id).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            mydb.SaveChanges();
        }
     public async Task<List<Project>> Read() => mydb.Projects.ToList<Project>();

        private readonly List<Project> _projects = new List<Project>();
          public void Update(Project item)
        {
            var a = mydb.Projects.Where(x => x.Id == item.Id).FirstOrDefault();
            if (a != null)
            {

               
                mydb.Update(a);
                mydb.SaveChanges();
            }
            else
            {
                throw new Exception("לא נמצא הפריט לעדכון");
            }
        }

        //public List<Project> GetAll() => _projects;
        //public Project GetById(int id) => _projects.Find(p => p.Id == id);
        //public void Add(Project project) => _projects.Add(project);
    }
}








    



