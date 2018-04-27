using BrandonPotter.XBox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer dispatcherTimer;
        XBoxController xBoxController; 




        public MainWindow()
        {

            InitializeComponent();

            dispatcherTimer = new DispatcherTimer(); 
            // Timer instellen
            dispatcherTimer.Interval = new TimeSpan(100000);
            dispatcherTimer.Tick += DispatcherTimer_Tick;

            //xbox controller opzoeken.
            xBoxController = XBoxController.GetConnectedControllers().FirstOrDefault(); // frist of default eerste of nullpointer

            // Als er een controller gevonden is, start de timer. 
            if (xBoxController !=null)
            {
                dispatcherTimer.Start(); 
            }


        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine(xBoxController.ThumbLeftX);
            // Debug.WriteLine(xBoxController.ThumbLeftY);

            sldr.Value = xBoxController.ThumbLeftX;
            sldr2.Value = xBoxController.ThumbLeftY; 







            // knoppen 

            if (xBoxController.ButtonStartPressed)
            {
                tbxStart.Background = Brushes.Green;
            }

            else
            {
                tbxStart.Background = Brushes.Red; 
            }
        }
    }
}
