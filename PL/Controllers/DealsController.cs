using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace DAL.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DealsController: ControllerBase
    {
        IBl bl;
        public DealsController(IBl bl)
        {
            this.bl = bl;
        }
        [HttpGet]
        [Route("GetAllDeals")]
       
        public async Task<List<BLdeal>> GetAllDeals()
        {
            if (bl == null) throw new Exception("bl is null");
            if (bl.Deal == null) throw new Exception("deal is null");

            var deals = await bl.Deal.GetAllDeals();

            if (deals == null) throw new Exception("GetAllDeals returned null");

            return deals;
        }
        [HttpPut]
        [Route("update/deal")]
        public void UpdateDeal(BLdeal deal)
        {
            bl.Deal.Update(deal);
        }
        [HttpPost]

        [Route("create/dealcreate/deal")]
        public bool CreateDeal([FromBody] BLdeal deal)
        {
            return bl.Deal.Create(deal);
        }





    }
}
