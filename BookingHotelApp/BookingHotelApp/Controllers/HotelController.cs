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
    public class HotelController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly HotelSvc _svc;
        public HotelController()
        {
            _svc = new HotelSvc();
        }

        [HttpPost("create-hotel")]
        public IActionResult CreateAccount([FromBody]HotelReq req)
        {
            var result = _svc.CreateHotel(req);
            return Ok(result);
        }

        [HttpGet("search-hotel-pagination/{size}/{page}")]
        public IActionResult SearchHotelPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchHotelPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-hotel")]
        public IActionResult UpdateHotel([FromBody]HotelReq req)
        {
            var result = _svc.UpdateHotel(req);
            return Ok(result);
        }

        [HttpDelete("remove-hotel/{hotelId}")]
        public IActionResult RemoveHotel(string hotelId)
        {
            var result = _svc.RemoveHotel(hotelId);
            return Ok(result);
        }
    }
}