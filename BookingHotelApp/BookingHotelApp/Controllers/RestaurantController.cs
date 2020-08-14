using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingHotelApp.BLL.Service;
using BookingHotelApp.Common.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly RestaurantSvc _svc;
        public RestaurantController()
        {
            _svc = new RestaurantSvc();
        }

        [HttpPost("create-restaurant")]
        public IActionResult CreateRestaurant([FromBody] RestaurantReq req)
        {
            var result = _svc.CreateRestaurant(req);
            return Ok(result);
        }
        [HttpGet("search-restaurant-pagination/{size},{page}")]
        public IActionResult SearchRestaurantPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchRestaurantPagination(size, page, keyWord);
            return Ok(result);
        }
        [HttpPut("update-restaurant")]
        public IActionResult UpdateRestaurant([FromBody] RestaurantReq req)
        {
            var result = _svc.UpdateRestaurant(req);
            return Ok(result);
        }

        [HttpDelete("remove-restaurant/{restaurantId}")]
        public IActionResult RemoveRestaurant(string restaurantId)
        {
            var result = _svc.RemoveRestaurant(restaurantId);
            return Ok(result);
        }
    }
}
