
using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAL.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IBl bl;
        // GET: api/<ControllerApi>
        public CustomersController(IBl bl) {
            this.bl = bl;
        }

        [HttpGet]
        [Route("GetAll")]

        public async Task<List<BLclient>> GetALLClient()
        {
            return await bl.Client.GetAll();
        }
        //public async Task<List<BLclient>> GetALLClient()
        //{
        //    return await bl.Client.GetAll().ToList();
        //}
        //tryout
        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<BLclient> GetClienDetailsthroghOrder(BLorder o)
        //{
        //    var li = await bl.Client.GetAll();
        //    var custid = o.CustId;
        //    var d = li.Find(x => x.CustomersId == custid);
        //    return d;
        //}
        [HttpGet]
        [Route("mail")]

       
        public async Task<BLclient> GetClientByMail(string mail)
        {
            var client =  bl.Client.GetClientById(mail);

            if (client == null)
                return null;

            return await client;
        }

        [HttpPost]
        
        public async Task<bool> CreateClient([FromBody] BLclient client)
        {
          return await bl.Client.Create(client);
        }
        [HttpPut]
        [Route("update/client")]
        public void UpdateClient(BLclient client) { 
        
           bl.Client.Update(client);
        }

        
    }
}
