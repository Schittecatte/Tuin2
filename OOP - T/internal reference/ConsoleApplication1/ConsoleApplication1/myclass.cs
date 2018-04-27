using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives
{
    class myclass
    {
        // Private data member 
        private string name;

        // Public property (referenced to itself)
        public myclass internalReference { get; set; }

        // Constructor 
        public myclass(string pName, myclass pInternalReference)
        {
            name = pName;
            internalReference = pInternalReference;


            // toch de private data bereiken. 
            if (pInternalReference != null)
            {
                internalReference.name = "Private data from me..."; 
            }





        }

      

    }
}
