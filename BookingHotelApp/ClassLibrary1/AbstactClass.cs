using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public abstract class AbstactClass : AbstractClass2, Interface, Interface2 //Abstract class can implement both on interface and abstract class
    {
        private int properties = 0; //Can create properties in abstract class but can't create abstract method
        public AbstactClass()
        {
            Console.WriteLine("Can create constructor in abstract class.");
        }
        public abstract int number(); //Abstract Method, can't set access modifier is private
        public void AbsMethodHasBody()
        {
            Console.WriteLine("Abstact method can has body.");
        }

        public void PublicInterfaceMethod()
        {
            Console.WriteLine("Implemented Method");
        }
    }
}
