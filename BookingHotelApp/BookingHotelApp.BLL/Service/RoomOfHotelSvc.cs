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
            roh.RoomOfHotelID = req.RoomOfHotelID;
            roh.RoomName = req.RoomName;
            roh.RoomAmount = req.RoomAmount;
            roh.BedAmount = req.BedAmount;
            roh.PeopleAmount = req.PeopleAmount;
            roh.PolicyApply = req.PolicyApply;
            roh.PolicyNotApply = req.PolicyNotApply;
            roh.CheckInTime = req.CheckInTime;
            roh.CheckOutTime = req.CheckOutTime;
            roh.RoomPriceForNight = req.RoomPriceForNight;
            roh.Discount = req.Discount;
            roh.Image = req.Image;
            roh.RoomsCreatedDate = req.RoomsCreatedDate;
            roh.RoomOfHotelNote = req.RoomOfHotelNote;
            roh.HotelID = req.HotelID;
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
            roh.RoomOfHotelID = req.RoomOfHotelID;
            roh.RoomName = req.RoomName;
            roh.RoomAmount = req.RoomAmount;
            roh.BedAmount = req.BedAmount;
            roh.PeopleAmount = req.PeopleAmount;
            roh.PolicyApply = req.PolicyApply;
            roh.PolicyNotApply = req.PolicyNotApply;
            roh.RoomPriceForNight = req.RoomPriceForNight;
            roh.Discount = req.Discount;
            roh.Image = req.Image;
            roh.RoomsCreatedDate = req.RoomsCreatedDate;
            roh.RoomOfHotelNote = req.RoomOfHotelNote;
            roh.HotelID = req.HotelID;
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
                || value.RoomName.Contains(keyWord)); //Kiểm tra theo tên phòng
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse SearchRoomOfHotelByHotelID(string hotelId)
        {
            SingleResponse result = new SingleResponse();
            var search = base.All.Where(value => value.HotelID == hotelId).ToList();
            result.Data = search;
            return result;
        }
        //public SingleResponse SearchRoomOfHotelByID(string roomOfHotelId)
        //{
        //    SingleResponse result = new SingleResponse();
        //    var search = base.All.Where(value => value.RoomOfHotelID == roomOfHotelId).FirstOrDefault();
        //    result.Data = search;
        //    return result;
        //}
        public SingleResponse RoomAndHotelInfoInBookingProcess(string roomOfHotelId)
        {
            var result = _rep.RoomAndHotelInfoInBookingProcess(roomOfHotelId);
            return result;
        }
        public SingleResponse RemoveRoomOfHotel(string roomOfHotelId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(roomOfHotelId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            var data = new
            {
                RoomOfHotelId = roomOfHotelId
            };
            result.Data = data;
            return result;
        }
        public SingleResponse CustomerSearchRoomByKeyword(string keyword)
        {
            SingleResponse result = new SingleResponse();
            result.Data = _rep.CustomerSearchRoomByKeyword(keyword);
            return result;
        }
    }
}
