using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives
{
    class Program
    {
        static void Main(string[] args)
        {
            Microcontroller arm = new Microcontroller("ST32f091rc", 48000000, 1);
            Microcontroller pic = new Microcontroller("PIC16F88", 320000000, 0.25);

            List<Microcontroller> mijnFavorieten = new List<Microcontroller>();
            mijnFavorieten.Add(arm);
            mijnFavorieten.Add(pic);
            mijnFavorieten.Add(new Microcontroller("ATmega328P",16000000,1));

            Console.WriteLine("Originele volgorde:");
            foreach (Microcontroller m in mijnFavorieten)
            {
                Console.WriteLine(m.ToString() + Environment.NewLine);
            }

            mijnFavorieten.Sort();


            Console.WriteLine("gesorteerde volgorde:");
            foreach (Microcontroller m in mijnFavorieten)
            {
                Console.WriteLine(m.ToString() + Environment.NewLine);
            }



            if (pic>arm)
            {
                Console.WriteLine("Pic is de meest krachtige");
            }

            else
            {
                Console.WriteLine("ARM is de meest krachtige");
            }



            Console.WriteLine("de hashcode van de ARM is: " + arm.GetHashCode().ToString());

            Microcontroller picCopy = pic;

            if (picCopy.Equals(pic))
                Console.WriteLine("PICCOPY EN PIC VERWIJZEN NAAR DE ZELFDE REFERENTIE");
            else
                Console.WriteLine("niet e"); 


            if (pic.GetHashCode() == picCopy.GetHashCode())
                Console.WriteLine("hebben de zelfde hashcode");





            Console.Read(); 



        }
    }
}
