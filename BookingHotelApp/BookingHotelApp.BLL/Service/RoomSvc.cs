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
    public class RoomSvc : GenericService<RoomRep, Room>
    {
        public SingleResponse CreateRoom(RoomReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Room room = new Room();
            //Gán
            room.RoomID = req.RoomID;
            room.RoomName = req.RoomName;
            room.RoomType = req.RoomType;
            room.RoomNote = req.RoomNote;
            //Trả về
            result = base.Create(room); //base gọi lớp cha
            result.Data = room;
            return result;
        }

        public SingleResponse UpdateRoom(RoomReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Room room = new Room();
            //Gán
            room.RoomID = req.RoomID;
            room.RoomName = req.RoomName;
            room.RoomType = req.RoomType;
            room.RoomNote = req.RoomNote;
            //Trả về
            result = base.Update(room); //base gọi lớp cha
            result.Data = room;
            return result;
        }

        public object SearchRoomPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.RoomID.Contains(keyWord) //Kiểm tra theo mã phòng
                || value.RoomName.Contains(keyWord)); //Kiểm tra theo tên
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemoveRoom(string roomId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(roomId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = roomId;
            return result;
        }
    }
}
