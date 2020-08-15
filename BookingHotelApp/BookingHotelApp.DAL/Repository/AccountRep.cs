using BookingHotelApp.Common.DAL;
using BookingHotelApp.Common.Request;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class AccountRep : GenericRepository<BookingHotelContext, Account>
    {
        public AccountRep()
        {
            Context = new BookingHotelContext(); //Context kế thừa từ generic
        }
        //Vì remove là hàm cần biến so sánh với trường cụ thể của 1 bảng. Nên sẽ viết cụ thể ở 1 Repository
        public SingleResponse Remove(string userName)
        {
            var dataRemove = Context.Account.FirstOrDefault(data => data.UserName == userName); //Tìm ra dữ liệu cần xóa
            return base.Remove(dataRemove); //Gọi hàm xóa từ đối tượng cha
        }
        
    }
}
