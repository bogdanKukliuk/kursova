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
        public string UserName { get; set; }
        private string BrendName { get; set; }
        private List<DetailsClass> _detalClassObj;
        private ConnectionClass connectionObj;
        public MainMenu()
        {
            //InitializeBrend();
            InitializeComponent();
             FillBase();
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
            ShowDetal();
        }

        private void Reno_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void Bmw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void Lada_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }



        private void Toyota_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void DOGE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void Subaru_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetal();
        }

        private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Detal.Visibility == Visibility.Visible)
            {
                Detal.Visibility = Visibility.Hidden;
                Carr.Visibility = Visibility.Visible;
            }
        }

        private void ShowDetal()
        {
            if (this.Detal.Visibility == Visibility.Hidden)
            {
                Detal.Visibility = Visibility.Visible;
                Carr.Visibility = Visibility.Hidden;
            }
        }

        private void InitializeBrend()
        {
            connectionObj = new ConnectionClass();
            _detalClassObj = connectionObj.DoReadClassDetal();
        }

        private void FillBase()
        {
            DetailsClass detailsClass = new DetailsClass();
            detailsClass.NameDetalClass = "rasdasd";

            _detalClassObj = new List<DetailsClass>();
            _detalClassObj.Add(detailsClass);

            connectionObj = new ConnectionClass();
            connectionObj.DoWriteDetalClass(_detalClassObj);
        }
        
    }
}
