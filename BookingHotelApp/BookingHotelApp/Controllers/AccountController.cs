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
    public class AccountController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly AccountSvc _svc;
        public AccountController()
        {
            _svc = new AccountSvc();
        }
        [HttpPost("create-account")]
        public IActionResult CreateAccount([FromBody]AccountReq req)
        {
            var result = _svc.CreateAccount(req);
            return Ok(result);
        }
    }
}