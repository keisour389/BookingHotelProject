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
    public class AccountSvc : GenericService<AccountRep, Account>
    {
        public SingleResponse CreateAccount(AccountReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Account account = new Account();
            //Gán
            account.UserName = req.UserName;
            account.Password = req.Password;
            account.AccountType = req.AccountType;
            account.AccountCreatedDate = req.AccountCreatedDate;
            account.AccountStatus = req.AccountStatus;
            account.Note = req.Note;
            //Trả về
            result = base.Create(account); //base gọi lớp cha
            result.Data = account;
            return result;
        }
        public SingleResponse UpdateAccount(AccountReq req)
        {
            //Khởi tạo
            var result = new SingleResponse();
            Account account = new Account();
            //Gán
            account.UserName = req.UserName;
            account.Password = req.Password;
            account.AccountType = req.AccountType;
            account.AccountCreatedDate = req.AccountCreatedDate;
            account.AccountStatus = req.AccountStatus;
            account.Note = req.Note;
            //Trả về
            result = base.Update(account);
            result.Data = account;
            return result;
        }
        public object SearchAccountPagination(int size, int page, string keyWord)
        {
            //Khởi tạo các đối tượng
            //Ban đầu sẽ là tất cả giá trị
            var resultAfterFill = base.All; //All là tất cả giá trị từ generic service
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Lọc dữ kiệu
                resultAfterFill = base.All.Where(value => value.UserName.Contains(keyWord) //Kiểm tra theo người dùng
                || value.AccountStatus.Contains(keyWord)); //Kiểm tra tình trạng tài khoản
            }
            //Kết quả
            return base.SearchPagination(size, page, resultAfterFill);
        }
        public SingleResponse RemoveAccount(string userName)
        {
            var result = new SingleResponse();
            result = _rep.Remove(userName); //_rep là biến protected, và _rep được get từ D
            result.Data = userName;
            return result;
        }
    }
}
