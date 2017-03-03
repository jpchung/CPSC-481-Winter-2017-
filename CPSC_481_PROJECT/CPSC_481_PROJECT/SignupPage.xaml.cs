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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481_PROJECT
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : UserControl
    {
        /// <summary>
        /// Initialize SignupPage UserControl elements
        /// </summary>
        public SignupPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switch from Sign-up Page to Login Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignupToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new LoginPage());
        }
    }
}
