using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        IBl bl;
      
        public CustomerTypeController(IBl bl)
        {
            this.bl = bl;
            
        }


        [HttpGet]

        [Route("GetAllTypes")]
       
        public async Task<List<BLcustomerType>> GetAllTypes()
        {
            if (bl == null) throw new Exception("bl is null");
            if (bl.CustomerType == null) throw new Exception("CustomerType is null");

            var types = await bl.CustomerType.GetAllTypes();

            if (types == null) throw new Exception("GetAllTypes returned null");

            return types;
        }








    }
}





