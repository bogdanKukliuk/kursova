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
            ShowDetal();
        }

        private void Reno_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 6;
            ShowDetal();
        }

        private void Bmw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 2;
            ShowDetal();
        }

        private void Lada_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 1;
            ShowDetal();
        }



        private void Toyota_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 9;
            ShowDetal();
        }

        private void DOGE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 4;
            ShowDetal();
        }

        private void Subaru_MouseDown(object sender, MouseButtonEventArgs e)
        {
            indificator = 7;
            ShowDetal();
        }

        private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.ClassDetal.Visibility == Visibility.Visible)
            {
                ClassDetal.Visibility = Visibility.Hidden;
                BrandCar.Visibility = Visibility.Visible;
                indificator = 0;
            }
        }

        private void ShowDetal()
        {
            if (this.ClassDetal.Visibility == Visibility.Hidden)
            {
                ClassDetal.Visibility = Visibility.Visible;
                BrandCar.Visibility = Visibility.Hidden;
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
    }
}
