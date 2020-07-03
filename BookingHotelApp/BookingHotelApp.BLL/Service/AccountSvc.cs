using BookingHotelApp.Common.BLL;
using BookingHotelApp.Common.Request;
using BookingHotelApp.DAL.Model;
using BookingHotelApp.DAL.Repository;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
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
            result = _rep.CreateAccount(account);
            result.Data = account;
            return result;
        }
    }
}
