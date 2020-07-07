using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common.Request
{
    public class EmployeeReq
    {
        public String EmployeeID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime EmpBirthDay { get; set; }
        public String EmpPhoneNumber { get; set; }
        public String EmpEmail { get; set; }
        public String EmpGender { get; set; }
        public String EmpAddress { get; set; }
        public String EmpIdentityCard { get; set; }
        public String Position { get; set; }
        public String Seniority { get; set; }
        public int Salary { get; set; }
        public String EmpBankCardType { get; set; }
        public String EmpBankCardID { get; set; }
        public DateTime EmpBankCardDate { get; set; }
        public String EmpNote { get; set; }
    }
}
