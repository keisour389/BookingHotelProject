using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class C : B
    {
        public void test()
        {
            string text = "";
            base.Create();
            base.Create(text);
            //Tạo đối tượng A, B, C
            A a = new A();
            B b = new B();
            C c = new C();
            c.test2(a);
        }
        public void test2(A a)
        {
            //ToDo
            base.number = 0;
        }
        
    }
}
