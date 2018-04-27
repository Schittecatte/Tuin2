using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("uncheckedVersion: {0}.", +UncheckedVersion());

            //Method maken die getallen optelt..
            Console.WriteLine("CheckedVersion: {0}", CheckedVersion()); 
            Console.ReadKey(); 
        }



        static int UncheckedVersion()
        {
            int z = 0;
            try
            {
                z = int.MaxValue;
                z = z + 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
           
            return z;
        }
        static int CheckedVersion()
        {
            int z = 0;
            try
            {
                z = int.MaxValue;
                z = checked(z + 100); // Checked Keyword gebruiken. 
                                    // Overflow detecteren. 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
            }
            return z; 
        }


    }



}
