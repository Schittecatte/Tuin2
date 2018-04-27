using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives
{
   public static class ShoppingCardExtensions
    {

       public static decimal TotalPrices
           (this ShoppingCart pShoppingCart)
       {
           decimal total = 0;

           foreach (Product p in pShoppingCart.Products)
           {
               total += p.Price;
           }

           return total; 
       }




    }
}
