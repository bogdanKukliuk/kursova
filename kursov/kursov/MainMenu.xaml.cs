using kursov.Context;
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
using System.Windows.Shapes;

namespace kursov
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private int indificator;
        public string UserName { get; set; }
        private string BrendName { get; set; }
        private List<DetailsClass> _brendName;
        public MainMenu()
        {
            //InitializeBrend();
            InitializeComponent();
            //Lul();
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

        private void Sex_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 3;
            ShowClassDetal();
        }

        private void Reno_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 6;
            ShowClassDetal();
        }

        private void Bmw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 2;
            ShowClassDetal();
        }

        private void Lada_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 1;
            ShowClassDetal();
        }

        private void Toyota_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 9;
            ShowClassDetal();
        }

        private void DOGE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 4;
            ShowClassDetal();
        }

        private void Subaru_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 7;
            ShowClassDetal();
        }

        private void btnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                ClassDetal.Visibility = Visibility.Visible;
            }
            else if(this.ClassDetal.Visibility == Visibility.Visible)
            {
                ClassDetal.Visibility = Visibility.Hidden;
                BrandCar.Visibility = Visibility.Visible;
            }
        }
            private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.ClassDetal.Visibility == Visibility.Visible || this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                ClassDetal.Visibility = Visibility.Hidden;
                BrandCar.Visibility = Visibility.Visible;
                indificator = 0;
            }
        }

        private void ShowClassDetal()
        {
            if (this.ClassDetal.Visibility == Visibility.Hidden)
            {
                ClassDetal.Visibility = Visibility.Visible;
                BrandCar.Visibility = Visibility.Hidden;
            }
        }
        private void ShowDetal()
        {
            if(this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                ClassDetal.Visibility = Visibility.Hidden;
            }
        }

        private void InitializeBrend()
        {
            ConnectionClass connectionObj = new ConnectionClass();
            _brendName = connectionObj.DoReadClassDetal();
        }
        private void Lul()
        {
            ConnectionClass connectionClass = new ConnectionClass();
            DetailsClass details = new DetailsClass();
            details.NameDetalClass = "rofl";
            _brendName = new List<DetailsClass>();
            _brendName.Add(details);
            connectionClass.DoWriteDetalClass(_brendName);
            
        }

        private void brakes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void electronics_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void oil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void transmission_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void wheel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void damper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void body_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }
        private void motor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            Close();
        }
    }
}
