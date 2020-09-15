using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface Interface
    {
        //Interface can't create constructor
        //public Interface()
        //{

        //}
        const int properties = 0; //Interface can't create properties if it don't has const data type

        private void PrivateInterfaceMethod()
        {
            Console.WriteLine("Interface method have the body if it has access modifier is private :D");
        }
        void PublicInterfaceMethod();
    }
}
