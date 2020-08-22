using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpPost("remove-login-session")]
        public IActionResult DeleteAccountSession()
        {
            HttpContext.Session.Clear();
            var result = new
            {
                Content = "Clear login session successfully"
            };
            return Ok(result);
        }
    }
}
