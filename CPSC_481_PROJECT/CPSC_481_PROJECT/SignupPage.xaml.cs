using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
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

        public static bool ValidSignup { get; set; }

        //timer for incorrect signup text prompt
        DispatcherTimer invalidSignupTextTimer = new DispatcherTimer();

        /// <summary>
        /// Initialize SignupPage UserControl elements
        /// </summary>
        public SignupPage()
        {
            InitializeComponent();
            ValidSignup = false;
            invalidSignupTextTimer.Tick += invalidSignupTextTimer_Tick;
            invalidSignupTextTimer.Interval = new TimeSpan(0, 0, 3); //timer lasts for 3 second interval

        }

        /// <summary>
        /// After interval time has ticked, hide invalid text prompt and stop timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invalidSignupTextTimer_Tick(object sender, EventArgs e)
        {
            InvalidSignupText.Visibility = Visibility.Hidden;

            invalidSignupTextTimer.Stop();
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
            bool inputFieldsEmpty;

            // lists for signup input fields
            var textBoxes = new TextBox[] { EmailInput, SignupUsernameInput, BattetagInput};
            var passwordBoxes = new PasswordBox[] { SignupPasswordBox, SignupConfirmPasswordBox };

            //if any input fields on signup page empty, set boolean
            if(textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text)) || passwordBoxes.Any(pb => string.IsNullOrEmpty(pb.Password)))
            {
                inputFieldsEmpty = true;
            }
            else
            {
                inputFieldsEmpty = false;
            }
            

            //check inputs before completing sign-up
            if (inputFieldsEmpty)
            {
                InvalidSignupPrompt("Please enter input for all fields!");
                ValidSignup = false;
            }
            else if (!String.Equals(SignupPasswordBox.Password, SignupConfirmPasswordBox.Password))
            {
                InvalidSignupPrompt("Password fields don't match!");
                ValidSignup = false;
            }
            else if (SignupUsernameInput.Text.Length > 20)
            {
                InvalidSignupPrompt("Maximum Username length is 20 characters");
                ValidSignup = false;
            }
            else
            {

                String newEmail = EmailInput.Text;
                String newUsername = SignupUsernameInput.Text; 
                String newPassword = SignupPasswordBox.Password; //password is case sensitive
                String newBattleTag = BattetagInput.Text;

                //set boolean for valid sign-up after checking for conflicts with existing users
                foreach (Profile user in MainWindow.UserList)
                {
                    String existingEmail = user.Email;
                    String existingBattleTag = user.BattleTag;
                    Dictionary<String, String> existingLogins = user.getUsernamePassword();

                    //check if signup info conflicts with existing user's info
                    if (String.Equals(newEmail, existingEmail))
                    {
                        InvalidSignupPrompt("This Email is already registered!");
                        ValidSignup = false;
                        break;
                    }
                    else if (String.Equals(newBattleTag, existingBattleTag))
                    {
                        InvalidSignupPrompt("This BattleTag is already registered!");
                        ValidSignup = false;
                        break;
                    }
                    else if (existingLogins.ContainsKey(newUsername))
                    {
                        InvalidSignupPrompt("This Username is already registered!");
                        ValidSignup = false;
                        break;
                    }
                    
                    else
                    {
                        ValidSignup = true;
                        
                    }

                }
    
               
            }

            if (ValidSignup)
            {
                String newEmail = EmailInput.Text;
                String newUsername = SignupUsernameInput.Text; //username case sensitive
                String newPassword = SignupPasswordBox.Password; //password is case sensitive
                String newBattleTag = BattetagInput.Text;

                //instantiate new user profile, add to list of user logins
                Profile newUser = new Profile(newEmail, newUsername, newPassword, newBattleTag);
                new SignupProfileSettingsWindow(newUser).ShowDialog();
            }

        }

        /// <summary>
        /// Display invalid signup text prompt with context, and start timer
        /// </summary>
        /// <param name="textPrompt"></param>
        private void InvalidSignupPrompt(String textPrompt)
        {
            InvalidSignupText.Text = textPrompt;
            InvalidSignupText.Visibility = Visibility.Visible;
            invalidSignupTextTimer.Start();
        }
    }
}
