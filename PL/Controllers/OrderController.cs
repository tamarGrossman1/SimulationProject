using BL.Api;
using BL.Models;
using BL.Services;
using DAL.Appi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{[ApiController]
    [Route("[controller]/[action]")]
    
    public class OrderController:ControllerBase
    {
        IBl bl;
        public OrderController(IBl bl)
        {
            this.bl = bl;
        }
        //upload file
        //[HttpPost]
        //public async Task<IActionResult> CreateOrder([FromForm] BLorder customer, IFormFile cvFile)
        //{
        //    if (cvFile != null && cvFile.Length > 0)
        //    {
        //        // שמירת הקובץ
        //        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        //        if (!Directory.Exists(uploadsFolder))
        //            Directory.CreateDirectory(uploadsFolder);

        //        var uniqueFileName = $"{Guid.NewGuid()}_{cvFile.FileName}";
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await cvFile.CopyToAsync(stream);
        //        }

        //        // שמירת שם הקובץ והנתיב במודל
        //        customer.FileName = uniqueFileName;
        //        customer.Url = filePath;

        //    }
        //}

            [HttpGet("GetAllorders")]
        public async Task<List<BLorder>> GetAllorders()
        {
            if (bl == null) throw new Exception("bl is null");
            if (bl.IblOrder == null) throw new Exception("deal is null");

            var types = await bl.IblOrder.GetAllorders();

            if (types == null) throw new Exception("GetAllDeals returned null");

            return types;
        }
        [HttpPut]
        [Route("update/order")]
        public void UpdateOrder(BLorder order)
        {
            bl.IblOrder.Update(order);
        }
        
        [HttpGet("{id}/customer")]
        public IActionResult GetCustomerByOrder(int id)
        {
            var result = bl.IblOrder.GetCustomerByOrderId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost("CreateOrder")]
        public bool CreateOrder([FromBody] BLorder order)
        {
            return bl.IblOrder.Create(order);
        }
    }
}

