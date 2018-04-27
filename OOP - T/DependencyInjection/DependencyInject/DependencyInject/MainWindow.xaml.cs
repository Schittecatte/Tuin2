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
using Vives;

namespace DependencyInject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Light light;
        Switch lightswitch;



        public MainWindow()
        {
            InitializeComponent();

            light = new Light();
            lightswitch = new Switch(light);        //Dependency Injection

            imglight.Source = new BitmapImage(new Uri("light-bulb-off.png", UriKind.Relative));



        }

        private void btnOnSwitch_Click(object sender, RoutedEventArgs e)
        {
            lightswitch.Up();
            if(light.IsOn)
            {
                imglight.Source = new BitmapImage(new Uri("light-bulb-on.png",UriKind.Relative));
            }
        }

        private void btnOffSwitch_Click(object sender, RoutedEventArgs e)
        {
            lightswitch.Down();
            if (!light.IsOn)
            {
                imglight.Source = new BitmapImage(new Uri("light-bulb-off.png", UriKind.Relative));
            }
        }
    }
}
