﻿using System;
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
            if (txtPassword.Password != txtPassword_R.Password)
            {
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPassword_R.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                var _login = new Login { Email = txtEmail.Text,  Password = txtPassword_R.Password };
                _context.Login.Add(_login);
                _context.SaveChangesAsync();
            }
        }
    }
}