using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives;

namespace ShoppingCartExtensions
{
    class Program
    {
        static void Main(string[] args)
        {

            // Nieuwe winkelwagen
            ShoppingCart shoppingCart = new ShoppingCart();

            // enkele producten maken via object initialiser. 

            Product kayak = new Product()
            {
                Name = "Kayak",
                Category = "Watersports",
                Price = 277,
               Related = null
            };
            Product lifejacket = new Product()
            {
                Name = "Lifejacket",
                Category = "Watersports",
                Price = 96,
                Related = kayak
            }; 
            // producten in de winkelkar leggen. 
            shoppingCart.Products = new Product[] {kayak, lifejacket};

            // standard codering goed zetten. (voor euro symbool)
            Console.OutputEncoding = Encoding.Default;

            Console.WriteLine("Total costs of the card: {0:C2}.",
                shoppingCart.TotalPrices());


            Console.ReadKey();
        }
    }
}
