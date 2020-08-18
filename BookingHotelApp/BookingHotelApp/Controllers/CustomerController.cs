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
    public class CustomerController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly CustomerSvc _svc;
        public CustomerController()
        {
            _svc = new CustomerSvc();
        }

        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody]CustomerReq req)
        {
            var result = _svc.CreateCustomer(req);
            return Ok(result);
        }

        [HttpGet("search-customer-pagination/{size},{page}")]
        public IActionResult SearchCustomerPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchCustomerPagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-customer")]
        public IActionResult UpdateCustomer([FromBody]CustomerReq req)
        {
            var result = _svc.UpdateCustomer(req);
            return Ok(result);
        }

        [HttpDelete("remove-customer/{customerId}")]
        public IActionResult RemoveCustomer(string customerId)
        {
            var result = _svc.RemoveCustomer(customerId);
            return Ok(result);
        }

        [HttpGet("check-account-exist/{username}")]
        public IActionResult CheckAccountExist(string username)
        {
            var result = _svc.CheckAccountExist(username);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetCustomerByPhoneNumber(string customerId)
        {
            var result = _svc.GetCustomerByPhoneNumber(customerId);
            return Ok(result);
        }
    }
}