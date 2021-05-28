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
    public class BookingController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly BookingSvc _svc;
        public BookingController()
        {
            _svc = new BookingSvc();
        }

        [HttpPost("create-booking")]
        public IActionResult CreateBooking([FromBody]BookingReq req)
        {
            var result = _svc.CreateBooking(req);
            return Ok(result);
        }

        [HttpGet("search-booking/{size},{page}")]
        public IActionResult SearchBookingPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchBookingPagination(size, page, keyWord);
            return Ok(result);
        }
        [HttpGet("search-by-booking-date")]
        public IActionResult SearchOrderByBookingDate(string hotelId, DateTime startDate, DateTime endDate)
        {
            var result = _svc.SearchOrderByBookingDate(hotelId, startDate, endDate);
            return Ok(result);
        }

        [HttpPut("update-booking")]
        public IActionResult UpdateBooking([FromBody]BookingReq req)
        {
            var result = _svc.UpdateBooking(req);
            return Ok(result);
        }

        [HttpDelete("remove-booking/{bookingId}")]
        public IActionResult RemoveBooking(int bookingId)
        {
            var result = _svc.RemoveBooking(bookingId);
            return Ok(result);
        }
    }
}