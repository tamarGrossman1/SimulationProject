using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{ [Route("[controller]/[action]")]
        [ApiController]
    public class ReconnendationController:ControllerBase
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
        {
            IBl bl;
            // GET: api/<ControllerApi>
            public ReconnendationController(IBl bl)
            {
                this.bl = bl;
            }

            [HttpGet]
            [Route("GetAllRecommendations")]

            public async Task<List<BLrecommend>> GetAllRecommendations()
            {
                return await bl.IblRecommend.GetAll();
            }
      
        [HttpGet]
        public async Task<bool> Hasorder(int custId)
        {
            var client = bl.IblRecommend.Hasorder(custId);
            return client != null;
        }
        [HttpPost]

        public async Task<bool> CreateRecommend([FromBody] BLrecommend recommend)
        {
            return await bl.IblRecommend.Create(recommend);
        }

    }
    }
