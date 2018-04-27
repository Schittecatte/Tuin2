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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Album> albums = new List<Album>();

        public MainWindow()
        {
            InitializeComponent();
            albums.Add(new Album(
                new BitmapImage(
                new Uri(@"file://C:\temp\oralb_pro-3000_8754128_1.jpg")),"Tandenborstel"
                ));
            albums.Add(new Album(
              new BitmapImage(
              new Uri(@"file://C:\temp\Domo_Broodrooster_DO970T__Toaster@@9gttdx11.jpg")), "Toaster"
              ));
              albums.Add(new Album(
                new BitmapImage(
                new Uri(@"file://C:\temp\Tama_VA50RS_Satin_Mahogany_Tamo_Ash_02.jpg")),"Tandenborstel"
                ));
            // data koppelen met ListView (via Databinding).

            lvDataBinding.ItemsSource = albums;




        }

        private void LvDataBinding_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Album album = lvDataBinding.SelectedItem as Album;
            if (album != null)
            {
                MessageBox.Show(album.Naam);
            }
        }
    }
}
