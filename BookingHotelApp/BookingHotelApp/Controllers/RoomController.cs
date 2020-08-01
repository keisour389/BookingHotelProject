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
    public class RoomController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly RoomSvc _svc;
        public RoomController()
        {
            _svc = new RoomSvc();
        }

        [HttpPost("create-room")]
        public IActionResult CreateAccount([FromBody]RoomReq req)
        {
            var result = _svc.CreateRoom(req);
            return Ok(result);
        }

        [HttpGet("search-room-pagination/{size},{page}")]
        public IActionResult SearchRoomPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchRoomPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-room")]
        public IActionResult UpdateRoom([FromBody]RoomReq req)
        {
            var result = _svc.UpdateRoom(req);
            return Ok(result);
        }

        [HttpDelete("remove-room/{roomId}")]
        public IActionResult RemoveRoom(string roomId)
        {
            var result = _svc.RemoveRoom(roomId);
            return Ok(result);
        }
    }
}