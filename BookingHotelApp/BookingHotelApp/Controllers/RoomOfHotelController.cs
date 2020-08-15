﻿using System;
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
    public class RoomOfHotelController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly RoomOfHotelSvc _svc;
        public RoomOfHotelController()
        {
            _svc = new RoomOfHotelSvc();
        }

        [HttpPost("create-room-of-hotel")]
        public IActionResult CreateRoomOfHotel([FromBody]RoomOfHotelReq req)
        {
            var result = _svc.CreateRoomOfHotel(req);
            return Ok(result);
        }

        [HttpGet("search-room-of-hotel-pagination/{size},{page}")]
        public IActionResult SearchRoomOfHotelPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchRoomOfHotelPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpGet("search-room-of-hotel-by-id")]
        public IActionResult SearchRoomOfHotelByID(string hotelId)
        {
            var result = _svc.SearchRoomOfHotelByID(hotelId);
            return Ok(result);
        }

        [HttpPut("update-room-of-hotel")]
        public IActionResult UpdateRoomOfHotel([FromBody]RoomOfHotelReq req)
        {
            var result = _svc.UpdateRoomOfHotel(req);
            return Ok(result);
        }

        [HttpDelete("remove-room-of-hotel/{hotelId},{roomId}")]
        public IActionResult RemoveRoomOfHotel(string hotelId, string roomId)
        {
            var result = _svc.RemoveRoomOfHotel(hotelId, roomId);
            return Ok(result);
        }

        //Procedure
        [HttpGet("customer-search-room-by-keyword")]
        public IActionResult CustomerSearchRoomByKeyword(string keyword)
        {
            //String hadLogin = HttpContext.Session.GetString("LoginSession"); //Nếu không có session này thì sẽ trả về null
            var result = _svc.CustomerSearchRoomByKeyword(keyword);
            //if (!String.IsNullOrEmpty(hadLogin))
            //{
            //    return Ok(result);
            //}
            //else
            //{
            //    var response = new
            //    {
            //        Success = false,
            //        Login = false
            //    };
            //    return Ok(response);
            //}
            return Ok(result);
        }
    }
}