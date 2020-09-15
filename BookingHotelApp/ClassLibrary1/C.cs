using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassLibrary1
{
    public class C : B
    {
        public new void test()
        {
            string text = "";
            base.Create();
            base.Create(text);
            //Tạo đối tượng A, B, C
            A a = new A();
            B b = new B();
            C c = new C();
            c.test2(c); //Hàm test2 lúc này khởi tạo tham số A nhưng t vẫn truyền B hoặc C vào
        }
        public void test2(A a)
        {
            //ToDo
            base.number = 0;
            ((C)a).test();
        }
        public delegate void TestDelegate();

        public static void UseDelegate()
        {
            Console.WriteLine("Use delegate");
        }
        public static void UseDelegate2()
        {
            Console.WriteLine("Use delegate 2");
        }
        public static void Delegate()
        {
            TestDelegate test = UseDelegate; //Gán hàm UseDelegate cho Delegate
            test(); //test lúc này là hàm Delegate 

            //Gán nhiều phương thức delegate
            test = UseDelegate;
            test += UseDelegate2;
            test += UseDelegate;
        }

        static int sum(int x, int y)
        {
            return x + y;
        }

        public static void UseFunc()
        {
            //Khởi tạo 1 func
            Func<int, int, int> tinhtong;//int cuối là kết quả trả về
            //Tham chiếu đến hàm sum
            tinhtong = sum;
            //Sử dụng
            tinhtong(1, 1); 
        }
    }
}
