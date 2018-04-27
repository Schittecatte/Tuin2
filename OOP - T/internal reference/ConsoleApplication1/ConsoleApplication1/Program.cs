using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            myclass object1 = new myclass("Vives",null);
            myclass object2 = new myclass("Kortrijk", object1);

            //.... Code Here.....

            Console.ReadKey(); 

        }
    }
}
