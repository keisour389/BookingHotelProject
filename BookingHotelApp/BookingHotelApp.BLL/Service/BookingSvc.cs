using BookingHotelApp.Common.BLL;
using BookingHotelApp.Common.Request;
using BookingHotelApp.DAL.Model;
using BookingHotelApp.DAL.Repository;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingHotelApp.BLL.Service
{
    public class BookingSvc : GenericService<BookingRep, Booking>
    {
        public SingleResponse CreateBooking(BookingReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Booking booking = new Booking();
            //Gán
            //Không gán mã, vì mã là số tự động tăng
            booking.BookingType = req.BookingType;
            booking.BookingDate = req.BookingDate;
            booking.BookingStatus = req.BookingStatus;
            booking.NumberOfPeople = req.NumberOfPeople;
            booking.CustomerPaymentMethods = req.CustomerPaymentMethods;
            booking.Required = req.Required;
            booking.Total = req.Total;
            booking.CustomerID = req.CustomerID;
            booking.EmployeeID = req.EmployeeID;
            booking.BookingNote = req.BookingNote;
            //Trả về
            result = base.Create(booking); //base gọi lớp cha
            result.Data = booking;
            return result;
        }

        public SingleResponse UpdateBooking(BookingReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Booking booking = new Booking();
            //Gán
            booking.BookingID = req.BookingID;
            booking.BookingType = req.BookingType;
            booking.BookingDate = req.BookingDate;
            booking.BookingStatus = req.BookingStatus;
            booking.NumberOfPeople = req.NumberOfPeople;
            booking.CustomerPaymentMethods = req.CustomerPaymentMethods;
            booking.Required = req.Required;
            booking.Total = req.Total;
            booking.CustomerID = req.CustomerID;
            booking.EmployeeID = req.EmployeeID;
            booking.BookingNote = req.BookingNote;
            //Trả về
            result = base.Update(booking); //base gọi lớp cha
            result.Data = booking;
            return result;
        }

        public object SearchBookingPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.BookingType.Contains(keyWord) //Kiểm tra theo loại đặt
                || value.BookingStatus.Contains(keyWord)); //Kiểm tra theo trạng thái đặt
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveBooking(int bookingId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(bookingId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = bookingId;
            return result;
        }
    }
}
