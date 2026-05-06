using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DAL.Controllers
{ [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectsController: ControllerBase
    { IBl bl;
      public ProjectsController(IBl bl)
        {
            this.bl = bl;
        } 
        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<List<BLproject>> GetAllProjects()
        {
            if (bl == null) throw new Exception("bl is null");
            if (bl.IblProject == null) throw new Exception("deal is null");

            var project = await bl.IblProject.GetAllProjects();

            if (project == null) throw new Exception("GetAllDeals returned null");

            return project;
        }
        [HttpPut]
        [Route("update/deal")]
        public void UpdateDeal(BLproject project)
        {
            bl.IblProject.Update(project);
        }
        [HttpPost]

        [Route("create/dealcreate/deal")]
        public bool Createproject([FromBody] BLproject project)
        {
            return bl.IblProject.Create(project);
        }





    }
}





