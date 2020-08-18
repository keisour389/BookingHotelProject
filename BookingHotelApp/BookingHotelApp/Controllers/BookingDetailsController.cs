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
    public class BookingDetailsController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly BookingDetailsSvc _svc;
        public BookingDetailsController()
        {
            _svc = new BookingDetailsSvc();
        }

        [HttpPost("create-booking-details")]
        public IActionResult CreateBookingDetails([FromBody]BookingDetailsReq req)
        {
            var result = _svc.CreateBookingDetails(req);
            return Ok(result);
        }

        [HttpGet("search-booking-details/{size},{page}")]
        public IActionResult SearchBookingDetailsPagination(int size, int page, int bookingId, string keyWord)
        {
            var result = _svc.SearchBookingDetailsPagination(size, page, bookingId, keyWord);
            return Ok(result);
        }

        [HttpPut("update-booking-details")]
        public IActionResult UpdateBookingDetails([FromBody]BookingDetailsReq req)
        {
            var result = _svc.UpdateBookingDetails(req);
            return Ok(result);
        }

        [HttpDelete("remove-booking-details/{bookingId}/{hotelId},{roomId}")]
        public IActionResult RemoveBookingDetails(int bookingId, string hotelId)
        {
            var result = _svc.RemoveBookingDetails(bookingId, hotelId);
            return Ok(result);
        }
    }
}