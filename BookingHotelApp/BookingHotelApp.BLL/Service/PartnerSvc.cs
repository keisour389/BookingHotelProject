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
    public class PartnerSvc : GenericService<PartnerRep, Partners>
    {
        public SingleResponse CreatePartner(PartnerReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Partners partners = new Partners();
            //Gán
            partners.PartnerId = req.PartnerId;
            partners.PartnerName = req.PartnerName;
            partners.DateOfCooperation = req.DateOfCooperation;
            partners.ManagerNumberPhone = req.ManagerNumberPhone;
            partners.Email = req.Email;
            partners.Office = req.Office;
            partners.TotalHotel = req.TotalHotel;
            partners.PartnerStatus = req.PartnerStatus;
            partners.PartnerNote = req.PartnerNote;
            //Tạo
            result = base.Create(partners);
            result.Data = partners;
            return result;
        }
        public SingleResponse UpdatePartner(PartnerReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Partners partners = new Partners();
            //Gán
            partners.PartnerId = req.PartnerId;
            partners.PartnerName = req.PartnerName;
            partners.DateOfCooperation = req.DateOfCooperation;
            partners.ManagerNumberPhone = req.ManagerNumberPhone;
            partners.Email = req.Email;
            partners.Office = req.Office;
            partners.TotalHotel = req.TotalHotel;
            partners.PartnerStatus = req.PartnerStatus;
            partners.PartnerNote = req.PartnerNote;
            //Tạo
            result = base.Update(partners);
            result.Data = partners;
            return result;
        }
        public object SearchPartnerPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.PartnerId.Contains(keyWord) //Kiểm tra theo mã người hợp tác
                || value.PartnerName.Contains(keyWord)); //Kiểm tra theo tên
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }

        public SingleResponse RemovePartner(string partnerId)
        {
            var result = new SingleResponse();
            result = _rep.Remove(partnerId); //Gọi lớp repository bởi vì mỗi điều kiện xóa khác nhau. Nên phải gọi cụ thể 1 repository
            result.Data = partnerId;
            return result;
        }
    }
}
