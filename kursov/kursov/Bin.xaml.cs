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
using System.Windows.Shapes;

namespace kursov
{
    /// <summary>
    /// Логика взаимодействия для Bin.xaml
    /// </summary>
    public partial class Bin : Window
    {
        public Bin()
        {
            InitializeComponent();
        }

        private void Lol_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dorou");
        }

        private void Lox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
