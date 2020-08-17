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
    public class EmpAccountController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly EmpAccountSvc _svc;
        public EmpAccountController()
        {
            _svc = new EmpAccountSvc();
        }
        [HttpGet("had-login")]
        public IActionResult HadLogin()
        {
            //Session sẽ có khi đăng nhập
            //Nếu không có session này thì sẽ trả về null
            String hadLogin = HttpContext.Session.GetString("EmpLoginSession");
            if (!String.IsNullOrEmpty(hadLogin))
            {
                var response = new
                {
                    Success = true,
                    Username = hadLogin
                };
                return Ok(response);
            }
            else
            {
                var response = new
                {
                    Success = false,
                    Username = ""
                };
                return Ok(response);
            }
        }


        [HttpPost("create-account")]
        public IActionResult CreateAccount([FromBody] AccountReq req)
        {
            var result = _svc.CreateAccount(req);
            return Ok(result);

        }

        [HttpGet("search-account-pagination/{size},{page}")]
        public IActionResult SearchAccountPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchAccountPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-account")]
        public IActionResult UpdateAccount([FromBody] AccountReq req)
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

        [HttpPost("validate-user")]
        public IActionResult ValidateUser([FromBody] UserReq req)
        {

            var result = _svc.ValidateUser(req);
            //Khi đã đăng nhập thành công thì sẽ tạo 1 session lưu tên người dùng
            if (result.Success)
            {
                HttpContext.Session.SetString("EmpLoginSession", req.Username);
            }
            return Ok(result);
        }
    }
}
