using BL.Api;
using BL.Models;
using DAL;
using DAL.Appi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace BL.Services
{
    public class BLprojectService : IblProject
    {
        Idal dal;

        public BLprojectService(Idal dal)
        {
            this.dal = dal;
        }
        public BLproject ConvertToBl(Project p)
        {
            return new() { Id = p.Id, Image = p.Image, FinalDate = p.FinalDate, CompName = p.CompNameCustName, PackageId = p.PackageId };

        }
        public Project convertToDal(BLproject p)
        {
            return new Project()
            { Id = p.Id, Image = p.Image, FinalDate = p.FinalDate, CompNameCustName = p.CompName, PackageId = p.PackageId };
        }
        public async Task<List<BLproject>> GetAllProjects()
        {
            List<BLproject> lst = new();
            dal.project.Read().Result.ForEach(d => lst.Add(ConvertToBl(d)));
            return lst;
        }
        public bool Update(BLproject item)
        {
            if (item == null) throw new ArgumentNullException("item");
            dal.project.Update(convertToDal(item));
            return true;
        }
        public bool Create(BLproject item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            else
            {
                dal.project.Create(convertToDal(item));
                return true;
            }

        }
    }
}
//        private readonly BLprojectService _dalService;
//        public ProjectService(BLprojectService dalService) => _dalService = dalService;

        //        public ProjectModel GetProject(int id)
        //        {
        //            var p = _dalService.GetById(id);
        //            return p == null ? null : new ProjectModel { Id = p.Id, Name = p.Name };
        //        }

        //        public void AddProject(ProjectModel project)
        //        {
        //            _dalService.Add(new Project { Id = project.Id, Name = project.Name, Description = "" });
        //        }
   


