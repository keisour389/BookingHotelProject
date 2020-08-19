using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookingHotelApp.BLL.Service;
using BookingHotelApp.Common.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

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

        [HttpGet("search-hotel-by-hotel-id")]
        public IActionResult SearchHotelByHotelID(string hotelId)
        {
            var result = _svc.SearchHotelByHotelID(hotelId);
            return Ok(result);
        }

        [HttpGet("search-hotel-pagination/{size},{page}")]
        public IActionResult SearchHotelPagination(int size, int page, string keyWord)
        {
            //HttpContext.Session.SetString("TestSession", size.ToString());
            String hadLogin = HttpContext.Session.GetString("TestSession"); //Nếu không có session này thì sẽ trả về null
            
            var result = _svc.SearchHotelPagination(size, page, keyWord);
            if(!String.IsNullOrEmpty(hadLogin))
            {
                return Ok(result);
            }
            else
            {
                var response = new
                {
                    Login = false
                };
                return Ok(response);
            }
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