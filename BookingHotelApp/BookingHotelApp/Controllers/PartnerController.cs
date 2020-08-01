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
    public class PartnerController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly PartnerSvc _svc;
        public PartnerController()
        {
            _svc = new PartnerSvc();
        }

        [HttpPost("create-partner")]
        public IActionResult CreateCustomer([FromBody]PartnerReq req)
        {
            var result = _svc.CreatePartner(req);
            return Ok(result);
        }

        [HttpGet("search-partner-pagination/{size},{page}")]
        public IActionResult SearchPartnerPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchPartnerPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-partner")]
        public IActionResult UpdateCustomer([FromBody]PartnerReq req)
        {
            var result = _svc.UpdatePartner(req);
            return Ok(result);
        }

        [HttpDelete("remove-partner/{partnerId}")]
        public IActionResult RemoveCustomer(string partnerId)
        {
            var result = _svc.RemovePartner(partnerId);
            return Ok(result);
        }
    }
}