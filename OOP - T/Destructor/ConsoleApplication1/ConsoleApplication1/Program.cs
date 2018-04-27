using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaVisitor[] visitors = new CinemaVisitor[4];

            visitors[0] =
                new CinemaVisitor("Donald", "Master of disaster");
            visitors[1] =
                new CinemaVisitor("Hillary", "Silence of the lambs");
            visitors[2] =
                new CinemaVisitor("Gary", "Gary voor de vrienden");
            visitors[3] =
                new CinemaVisitor("Jill", "Up hill");

            foreach (CinemaVisitor b in visitors)
                Console.WriteLine(b);

            Console.WriteLine("At this moment, there are " +
                CinemaVisitor.ActualNumberOfVisitors + " visitors in de cinema.");

            Console.WriteLine("Donald tired of it. He runs out...");

            visitors[0] = null;       // Verbinding heap en stack 'verbreken'...

            // Onderstaand lijnen zijn optioneel.
            GC.Collect();                   // Vuilnis verzamelen.
            GC.WaitForPendingFinalizers();  // Wachten tot alles opgekuist is..

            Console.WriteLine("At this moment, there are " +
               CinemaVisitor.ActualNumberOfVisitors + " visitors in de cinema.");

            Console.WriteLine("The type is: " + visitors[2].GetType().Name.ToString());
            Console.ReadKey();
        }
    }
}
