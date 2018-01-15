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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private int gamno;
        public string UserName { get; set; }
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = $"You logined as { UserName }";
        }

        private void btnBin_Click(object sender, RoutedEventArgs e)
        {
            Bin bin = new Bin();
            bin.ShowDialog();
            Close();
        }
        /*
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
                
            }
            btnSearch.IsEnabled = false;
        }
        */

        private void Sex_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
            }
        }

        private void Reno_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
            }
        }

        private void Bmw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
            }
        }

        private void Lada_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
            }
        }

        private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                Carr.Visibility = Visibility.Visible;
            }
        }

        private void Toyota_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                Carr.Visibility = Visibility.Visible;
            }
        }

        private void DOGE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                Carr.Visibility = Visibility.Visible;
            }
        }

        private void Subaru_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                Carr.Visibility = Visibility.Visible;
            }
        }

        
    }
}
