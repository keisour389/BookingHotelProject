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
        //Xác thực việc gửi API, phòng ngừa việc gửi API giả mạo
        //Ngăn việc lấy đường link API từ web này mà gửi từ web khác
        [ValidateAntiForgeryToken] 
        public IActionResult CreateAccount([Bind("UserName,Password,AccountType,AccountCreatedDate,AccountStatus")]
            AccountReq req)
        {
            if(ModelState.IsValid)
            {
                var result = _svc.CreateAccount(req);
                return Ok(result);
            }
            return Ok("failed");
        }

        [HttpGet("search-account-pagination/{size},{page}")]
        public IActionResult SearchAccountPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchAccountPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-account")]
        public IActionResult UpdateAccount([FromBody]AccountReq req)
        {
            var result = _svc.UpdateAccount(req);
            return Ok(result);
        }

        [HttpDelete("remove-account/{userName}")]
        public IActionResult RemoveAccount(string userName)
        {
            var result = _svc.RemoveAccount(userName);
            return Ok(result);
        }
    }
}