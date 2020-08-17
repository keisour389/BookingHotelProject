using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace BookingHotelApp.Common
{
    public class Encrypt
    {
        public static string GetMDHash(string input)
        {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] b = Encoding.UTF8.GetBytes(input);
                b = md5.ComputeHash(b);
                StringBuilder sb = new StringBuilder();
                foreach(byte x in b)
                {
                    sb.Append(x.ToString("x2")); //Chuyển sang định dạng Hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}
