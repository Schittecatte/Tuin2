using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exmet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // als omzetting geukt is, verplaats de knop via extension method... 
                btn.MoveLeft(10);

            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            // de knop waarvan je vertrekt, ophalen en omzetten
            Button btn = sender as Button;
            //of alternatief
         //Button btn = (Button) sender;

            if (btn != null)
            {
                // als omzetting geukt is, verplaats de knop via extension method... 
                btn.MoveRight(10);

            }

        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
