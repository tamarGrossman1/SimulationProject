using BL.Api;
using BL.Models;
using DAL.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace DAL.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IllustrationController : ControllerBase
    {
        IBl bl;
        public IllustrationController(IBl bl)
        {
            this.bl = bl;
        }
      [HttpGet]
    [Route("GetAllIllustration")]
        //mine
        //public async  Task<List<BLillustrationViewPoint>> GetAllIllustration()
        //{
        //    if (bl == null) throw new Exception("bl is null");
        //    if (bl.IblIllustrationViewPoint == null) throw new Exception("deal is null");
        //    var types = bl.IblIllustrationViewPoint.GetAllIllustration().Result;
        //    if (types == null) throw new Exception("GetAllDeals returned null");
        //    return await  types.ToListAsync();

        //}
        //the binas
        
        public async Task<List<BLillustrationViewPoint>> GetAllIllustration()
        {
            if (bl == null) throw new Exception("bl is null");
            if (bl.IblIllustrationViewPoint == null) throw new Exception("deal is null");
            var types = await bl.IblIllustrationViewPoint.GetAllIllustration();
            if (types == null) throw new Exception("GetAllDeals returned null");
            return types;
        }


    } }






       


















namespace API.Controllers
{
    public class IllustrationController
    {
    }
}
