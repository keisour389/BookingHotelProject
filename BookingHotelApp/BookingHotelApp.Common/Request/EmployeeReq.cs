using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class EmployeeReq
    {
        public String PhoneNumber { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime EmpBirthDay { get; set; }
        public String EmpEmail { get; set; }
        public String EmpGender { get; set; }
        public String Street { get; set; }
        public String Ward { get; set; }
        public String District { get; set; }
        public String Province { get; set; }
        public String Country { get; set; }
        public String EmpIdentityCard { get; set; }
        public String Position { get; set; }
        public String Seniority { get; set; }
        public float CoefficientsSalary { get; set; }
        public String EmpNote { get; set; }
    }
}
