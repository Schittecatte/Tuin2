using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Newtonsoft.Json;
using Vives;
using System.Diagnostics;

namespace JSONandLINK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StreamReader sr;
        List<TreeInfo> myTrees;

        


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnChooseFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "JSON-file (*.json)|*.json";
            bool? result = ofd.ShowDialog(); // nullable boolean, kan true false en null zijn 
            if ((bool)result )
            {
                sr = new StreamReader(ofd.FileName);
                lblFile.Content = System.IO.Path.GetFileName(ofd.FileName);
                tbxTextToFind.IsEnabled = true;
                Debug.WriteLine(sr.ReadToEnd()); 
                myTrees = JsonConvert.DeserializeObject<List<TreeInfo>>(
                    sr.ReadToEnd()
                ); 
            }


        }

     
        private void TbxTextToFind_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Linq Query maken
            var treesFound = from tree in myTrees
                             let treeType = tree.TreeType.ToUpper()
                             where treeType.Contains(tbxTextToFind.Text.ToUpper())
                             orderby tree.TreeType
                             select tree.TreeType;

            // Listbox leegmaken
            lbxTreeInfo.Items.Clear();

            // Gevonden bomen toevoegen.
            foreach (string t in treesFound)
            {
                lbxTreeInfo.Items.Add(t);
            }

        }
    }
}
