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

namespace igraXO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            cbIgrac.Items.Add("X");
            cbIgrac.Items.Add("O");
        }

        private void cbIgrac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cbIgrac.SelectedItem as string;
            if(selected != null || !string.IsNullOrEmpty(Ime))
            {
                windowIgrica wi = new windowIgrica(selected,Ime);
                wi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste uneli ime ili niste izabrali tip igraca");
            }
            
            
        }
    }
}
