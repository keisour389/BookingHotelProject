using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotelApp.Common
{
    public class PasswordHasher
    {
        //Băm mật khẩu
        public static string HashPassword(string password)
        {
            return Encrypt.GetMDHash(password);
        }
        //Kiểm tra mật khẩu dưới dạng băm
        public static bool VertifyHasherPassword(string hashedPassword, string providedPassword)
        {
            if(hashedPassword == HashPassword(providedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
