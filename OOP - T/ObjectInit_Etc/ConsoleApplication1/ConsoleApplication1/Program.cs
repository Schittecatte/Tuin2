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

        // enumeratie opzetten
        enum Leefgebieden
        {
            Badkamer = 1,
            Woonkamer,
            Toilet,
            Tuin,
            Amazone,
            Toendra

        };

        static void Main(string[] args)
        {


            // nieuw object maken op een lange manier

            RgbLed led1 = new RgbLed();
            led1.Red = 255;
            led1.Green = 0;
            led1.Blue = 154;
            led1.Intensity = 255;


            // Nieuw object maken. Op een kortere manier met object initialisers...

            RgbLed led2 = new RgbLed
            {
                Red = 255,
                Blue = 24,
                Green = 24,
                Intensity = 255
            };

            // Var keyword gebruiken om variabele te maken waarvan je op dit moment nog niet weet welk type het wordt.
            var led3 = new RgbLed
            {
                Red = 255,
                Blue = 24,
                Green = 24,
                Intensity = 255
            };

            Console.WriteLine("He Type van led3 is:" + led3.GetType());
          

            //led3 = new DateTime(); lukt niet = Type safe

            // 'object' keyword gebruiken
            // LET OP NIET TYPE SAFE!!!!!
            object led4 = new RgbLed
            {
                Red = 255,
                Blue = 24,
                Green = 24,
                Intensity = 255
            };
            Console.WriteLine("He Type van led4 is:" + led4.GetType().ToString());
            Console.WriteLine("De Rode Kleur is:" + ((RgbLed)led4).Red);
            led4= new DateTime();



            // Nieuw 'anonieme types' maken 

            var krokodil = new {Naam = "Zappy", Lengte = 2.56, Leefgebied = Leefgebieden.Badkamer};

            Console.WriteLine("krokodil type :" + krokodil.GetType().ToString());


            Console.WriteLine("De krokodinaam is:" + krokodil.Naam);

            // producten maken en via LINQ zoeken met anoniem type. 
            // als resultaat. 

            Dictionary<string,Products> magazijn = new Dictionary<string, Products>();

            Products item1 = new Products
            {
                Naam = "Soeptas",
                Eenheidsprijs = 18.45,
                Kleur = "wit",
                Locatie = "rek 42",
                Massa = 0.24
            };

            Products item2 = new Products
            {
                Naam = "Handtas",
                Eenheidsprijs = 59.45,
                Kleur = "zwart",
                Locatie = "rek 62",
                Massa = 1.5
            };

            magazijn.Add(item1.Naam,item1);
            magazijn.Add(item2.Naam, item2);
            // ter plaatse magazijn filteren
            var opgekuistMagazijn = from item in magazijn
                select new
                {
                    item.Value.Naam,
                    Prijs = item.Value.Eenheidsprijs // eenheidsprijs hernoemd naar prijs 
                };

            Console.WriteLine("het type van opgekuist magazijn is:" + opgekuistMagazijn.GetType().ToString());

            Console.WriteLine("Stock in magazijn:");
            Console.WriteLine("--------------------");
            foreach (var item in opgekuistMagazijn)
            {
                Console.WriteLine("naam: " + item.Naam + " Eenheidsprijs:" +item.Prijs);
            }









            Console.ReadLine(); 




        }
    }
}
