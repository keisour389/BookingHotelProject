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
    public class EmployeeController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly EmployeeSvc _svc;
        public EmployeeController()
        {
            _svc = new EmployeeSvc();
        }

        [HttpPost("create-employee")]
        public IActionResult CreateCustomer([FromBody]EmployeeReq req)
        {
            var result = _svc.CreateEmployee(req);
            return Ok(result);
        }

        [HttpGet("search-employee-pagination/{size}/{page}")]
        public IActionResult SearchCustomerPagination(int size, int page, string keyWord)
        {
            var result = _svc.SearchEmployeePagination(size, page, keyWord);
            return Ok(result);
        }

        [HttpPut("update-employee")]
        public IActionResult UpdateCustomer([FromBody]EmployeeReq req)
        {
            var result = _svc.UpdateEmployee(req);
            return Ok(result);
        }

        [HttpDelete("remove-employee/{employeeId}")]
        public IActionResult RemoveEmployee(string employeeId)
        {
            var result = _svc.RemoveEmployee(employeeId);
            return Ok(result);
        }
    }
}