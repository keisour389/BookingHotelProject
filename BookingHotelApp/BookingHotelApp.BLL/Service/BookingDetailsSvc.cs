﻿using BookingHotelApp.Common.BLL;
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
    public class BookingDetailsSvc : GenericService<BookingDetailsRep, BookingDetails>
    {
        public SingleResponse CreateBookingDetails(BookingDetailsReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            BookingDetails bookingDetails = new BookingDetails();
            //Gán
            bookingDetails.BookingID = req.BookingID;
            bookingDetails.RoomOfHotelID = req.RoomOfHotelID;
            bookingDetails.NightAmount = req.NightAmount;
            bookingDetails.Price = req.Price;
            bookingDetails.SpecialRequirements = req.SpecialRequirements;
            //Trả về
            result = base.Create(bookingDetails); //base gọi lớp cha
            result.Data = bookingDetails;
            return result;
        }

        public SingleResponse UpdateBookingDetails(BookingDetailsReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            BookingDetails bookingDetails = new BookingDetails();
            //Gán
            bookingDetails.BookingID = req.BookingID;
            bookingDetails.RoomOfHotelID = req.RoomOfHotelID;
            bookingDetails.NightAmount = req.NightAmount;
            bookingDetails.Price = req.Price;
            bookingDetails.SpecialRequirements = req.SpecialRequirements;
            //Trả về
            result = base.Update(bookingDetails); //base gọi lớp cha
            result.Data = bookingDetails;
            return result;
        }

        public object SearchBookingDetailsPagination(int size, int page, int bookingId, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.BookingID == bookingId //Kiểm tra theo mã đặt
                || value.RoomOfHotelID.Contains(keyWord)); //Kiểm tra theo mã phòng của khách sạn
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveBookingDetails(int bookingId, string hotelId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(bookingId, hotelId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            var data = new
            {
                BookingId = bookingId,
                HotelId = hotelId
            };
            result.Data = data;
            return result;
        }
    }
}
