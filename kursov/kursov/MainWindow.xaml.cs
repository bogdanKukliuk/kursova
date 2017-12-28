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
        private RegistrationForm registrationForm;
        private MainMenu mainMenu;
        private string _role;
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
            mainMenu = new MainMenu();

            if (!backgroundWorker.IsBusy)
            {
                //backgroundWorker.RunWorkerAsync();
                DoConnect(null, null);
            }
            else
                backgroundWorker.CancelAsync();

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
                    var roles=user.Role;
                    
                    if(roles.SingleOrDefault(r => r.RoleName == "User") != null)
                    {
                        _role = "User";

                        if (roles.SingleOrDefault(r => r.RoleName == "Admin") != null)
                        {
                            _role +=" " +"Admin";
                        }
                    }
                    mainMenu.UserName = user.Name;
                    this.Hide();
                    mainMenu.ShowDialog();
                    this.Close();
                    
                }
                MessageBox.Show($"Entered Wrong data {user.Name + user.Password + user.Email}");
                return;
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
            registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
    }
}
