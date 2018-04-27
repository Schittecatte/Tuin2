using System;
using System.Collections;
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

            // Zonder Path
            Console.WriteLine("Alle omgevingsvariabelen, behalve PATH");
            Console.WriteLine("---------------------------------------");

            foreach (DictionaryEntry dictEnt in Environment.GetEnvironmentVariables())
            {
                if (dictEnt.Key.ToString() != "Path")
                {
                    Console.WriteLine("{0} = {1}\n",dictEnt.Key,dictEnt.Value);
                }
            }

            // Enkel Path 

            IDictionary de = Environment.GetEnvironmentVariables();
            string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Process);

            string[] paden = path.Split(';');

            foreach (string s in paden)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(Environment.GetEnvironmentVariable(
                "PATHEXT",EnvironmentVariableTarget.Machine));












            Console.ReadLine(); 






        }
    }
}
