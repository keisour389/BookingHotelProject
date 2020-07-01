using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookingHotelApp.Common.DAL
{
    //T là generic được xem như 1 class
    public interface IGenericRepository<T> where T : class
    {
        #region Methods
        public void Create(T table);

        public void CreateRange(List<T> listTable);

        public IQueryable<T> Read(Expression<Func<T, bool>> parameter); //Param ở đây là cú pháp lambda có input là T và output là bool

        public void Update(T table);

        public void UpdateRange(List<T> listTable);
        #endregion

        #region Properties
        IQueryable<T> All { get; } //Get All data in table
        #endregion

    }
}
