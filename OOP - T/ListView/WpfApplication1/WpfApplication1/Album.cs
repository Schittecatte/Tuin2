using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Vives
{
    class Album
    {
        public ImageSource Foto { get; set; }
        public string Naam { get; set; }

        public Album(ImageSource pImageSource, string pNaam)
        {
            Foto = pImageSource;
            Naam = pNaam; 
        }












    }
}
