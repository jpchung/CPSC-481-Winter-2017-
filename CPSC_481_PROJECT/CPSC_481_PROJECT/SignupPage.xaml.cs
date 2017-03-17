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

        /// <summary>
        /// Add new Profile in MainWindow UserList based on signup info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignupToMainButton_Click(object sender, RoutedEventArgs e)
        {
            bool inputFieldsEmpty = false;

            // lists for signup input fields
            var textBoxes = new TextBox[] { EmailInput, SignupUsernameInput, BattetagInput};
            var passwordBoxes = new PasswordBox[] { SignupPasswordBox, SignupConfirmPasswordBox };

            //if any input fields on signup page empty, set boolean
            if(textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text)) || passwordBoxes.Any(pb => string.IsNullOrEmpty(pb.Password)))
            {
                inputFieldsEmpty = true;
            }

            if (inputFieldsEmpty)
            {

            }
            else if(!inputFieldsEmpty)
            {
                //Profile newUser = new Profile();
                new SignupProfileSettingsWindow().ShowDialog();
                PageSwitcher.Switch(new MainPage());
            }

                
            


        }
    }
}
