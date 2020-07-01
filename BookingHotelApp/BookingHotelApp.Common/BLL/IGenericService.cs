using LTCSDL.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookingHotelApp.Common.BLL
{

    //T được xem như 1 class
    public interface IGenericService<T> where T : class
    {
        #region Methods
        SingleRespone Create(T table);

        MultipleResponse CreateRange(List<T> listTable);

        IQueryable<T> Read(Expression<Func<T, bool>> parameter); //Param ở đây là cú pháp lambda có input là T và output là bool

        SingleRespone Update(T table);

        MultipleResponse UpdateRange(List<T> table);

        #endregion

        #region Properites
        IQueryable<T> All { get; }
        #endregion
    }
}
