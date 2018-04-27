using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WieZoektDieVindt
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1)
            {
                Console.WriteLine("Wally is " + args[0]);
            }
            else
            {
                Console.WriteLine("Geef 1 command line mee");
            }
            Console.ReadLine();

            // Path naar programma in omgevingsvar gezet
            // dan windows + r en naam programma
        }
    }
}
