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
using kursov.Context;
using System.Data.Entity;

namespace kursov
{
    /// <summary>
    /// Логика взаимодействия для RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        private EFContext _context;
        public RegistrationForm()
        {
            _context = new EFContext();
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password != txtPassword_R.Password)
                {
                    txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtPassword_R.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    var user = new User
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword_R.Password,
                        Money = 0,
                        Name = txtName.Text
                    };
                    _context.User.Add(user);
                    _context.SaveChanges();

                    var role = _context.Role.Include(l => l.User).SingleOrDefault(r => r.RoleName == "User");
                    
                    if(role != null)
                    {
                        role.User.Add(user);
                        _context.SaveChanges();
                    }
                    //MessageBox.Show(user.Email + user.Password + user.Money + user.Name + role.RoleName + role.Login.ToString());
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
                Environment.Exit(1);
                throw;
            }
            
        }
    }
}
