using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class B : A
    {
        protected int number = 0;

        protected static string PrintSomeText()
        {
            return "Some texts";
        }
        public void test()
        {
            Console.WriteLine("test");
        }
        public void Create(string text)
        {
            //TODO
        }
    }
}
