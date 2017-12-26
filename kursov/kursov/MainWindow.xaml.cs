using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using kursov.Context;
using System.Windows.Threading;
using System.Data.Entity;

namespace kursov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EFContext _efContext;
        private readonly BackgroundWorker backgroundWorker;

        private string role;
        public string _Role { set { role = value; } }
        public MainWindow()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += DoConnect;
            backgroundWorker.WorkerSupportsCancellation = true;
            InitializeComponent();
            _efContext = new EFContext();
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
            else
                backgroundWorker.CancelAsync();

            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        private void DoConnect(object sender, DoWorkEventArgs e)
        {
            try
            {
                string email = txtEmail.Dispatcher.Invoke(new Func<string>(() =>
                {
                    return txtEmail.Text;
                }));
                string password = txtPassword.Dispatcher.Invoke(new Func<string>(() =>
                {
                    return txtPassword.Password;
                }));
                var user = _efContext.Login.Include(r => r.Role).SingleOrDefault(u => u.Password == password &&
                  u.Email == email);

                if (user != null)
                {
                    return;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }


        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            _efContext = new EFContext();
        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.ShowDialog();
        }
    }
}
