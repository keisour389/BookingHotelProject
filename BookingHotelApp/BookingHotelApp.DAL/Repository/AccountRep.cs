using BookingHotelApp.Common.DAL;
using BookingHotelApp.Common.Request;
using BookingHotelApp.DAL.Model;
using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.DAL.Repository
{
    public class AccountRep : GenericRepository<BookingHotelContext, Account>
    {
        public AccountRep()
        {
            Context = new BookingHotelContext();
        }
        public SingleResponse CreateAccount(Account account)
        {
            var result = new SingleResponse();
            using(var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Create(account); //Create của generic repository
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result.SetError(ex.StackTrace);
                    tran.Rollback();
                }
            }
            return result;
        }
    }
}
