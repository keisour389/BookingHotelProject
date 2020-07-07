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
    public class RoomOfHotelSvc : GenericService<RoomOfHotelRep, RoomOfHotel>
    {
        public SingleResponse CreateRoomOfHotel(RoomOfHotelReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            RoomOfHotel roh = new RoomOfHotel();
            //Gán
            roh.HotelID = req.HotelID;
            roh.RoomID = req.RoomID;
            roh.RoomAmount = req.RoomAmount;
            roh.RoomPriceForNight = req.RoomPriceForNight;
            roh.Discount = req.Discount;
            roh.Image = req.Image;
            roh.RoomsCreatedDate = req.RoomsCreatedDate;
            roh.RoomOfHotelNote = req.RoomOfHotelNote;
            //Trả về
            result = base.Create(roh); //base gọi lớp cha
            result.Data = roh;
            return result;
        }

        public SingleResponse UpdateRoomOfHotel(RoomOfHotelReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            RoomOfHotel roh = new RoomOfHotel();
            //Gán
            roh.HotelID = req.HotelID;
            roh.RoomID = req.RoomID;
            roh.RoomAmount = req.RoomAmount;
            roh.RoomPriceForNight = req.RoomPriceForNight;
            roh.Discount = req.Discount;
            roh.Image = req.Image;
            roh.RoomsCreatedDate = req.RoomsCreatedDate;
            roh.RoomOfHotelNote = req.RoomOfHotelNote;
            //Trả về
            result = base.Update(roh); //base gọi lớp cha
            result.Data = roh;
            return result;
        }

        public object SearchRoomOfHotelPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.HotelID.Contains(keyWord) //Kiểm tra theo mã khách sạn
                || value.RoomID.Contains(keyWord)); //Kiểm tra theo mã phòng
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveRoomOfHotel(string hotelId, string roomId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(hotelId, roomId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            var data = new
            {
                HotelId = hotelId,
                RoomId = roomId
            };
            result.Data = data;
            return result;
        }
    }
}
