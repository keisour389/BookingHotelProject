using BookingHotelApp.Common.DAL;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class EmployeeRep : GenericRepository<BookingHotelContext, Employees>
    {
        public EmployeeRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse Remove(string employeeId)
        {
            var dataRemove = Context.Employees.FirstOrDefault(data => data.PhoneNumber == employeeId);
            return base.Remove(dataRemove); //Gọi hàm remove từ đối tượng cha
        }
    }
}
