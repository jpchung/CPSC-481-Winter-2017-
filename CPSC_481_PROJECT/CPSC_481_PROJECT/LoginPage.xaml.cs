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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481_PROJECT
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        /// <summary>
        /// Initialize LoginPage UserControl elements
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switch from Login Page to Sign-up Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginToSignupButton_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new SignupPage());
        }

        private void LoginToMainButton_Click(object sender, RoutedEventArgs e)
        {
            //super janky login, but it works lol
            if(!MainWindow.UserList.ElementAt(0).getUsernamePassword().ContainsKey(UsernameInput.Text))
            {

            }
            else
            {
                PageSwitcher.Switch(new MainPage());
            }
        }
    }
}
