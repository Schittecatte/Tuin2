using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Exmet
{
    public static class extensionButton
    {

        public static void MoveRight(this Button pButton, int pDistance)
        {



            pButton.Margin = new System.Windows.Thickness(pButton.Margin.Left + pDistance, pButton.Margin.Top, 0, 0);





        }


        public static void MoveLeft(this Button pButton,
        int pDistance)
        {



            pButton.Margin = new System.Windows.Thickness(pButton.Margin.Left - pDistance, pButton.Margin.Top, 0, 0);





        }



        public static void MoveTop(this Button pButton,
        int pDistance)
        {



           




        }
    }
}
