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
using System.Windows.Controls.Primitives;

namespace CPSC_481_PROJECT
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {

        private Profile userProfile;
    
       /// <summary>
       /// Initialize MainPage UserControl elements
       /// </summary>
        public MainPage(int userIndex)
        {
            InitializeComponent();
            
            //instantiate dropdown list items
            RoleComboBox.ItemsSource = Profile.RolesList;
            HeroComboBox.ItemsSource = Profile.HeroesList;
            GameModeComboBox.ItemsSource = Profile.GameModesList;

            SoloSearchRoleComboBox.ItemsSource = Profile.RolesList;
            SoloSearchHeroComboBox.ItemsSource = Profile.HeroesList;

            SoloSearchQuickplayToggle.IsChecked = true;
            GroupSearchQuickplayToggle.IsChecked = true;

            //load logged in User's profile from the UserList
            userProfile = MainWindow.UserList.ElementAt(userIndex);
            ProfileUsername.Text = userProfile.getUsernamePassword().Keys.ElementAt(0);
            RoleComboBox.SelectedItem = userProfile.Role;
            HeroComboBox.SelectedItem = userProfile.Hero;
            GameModeComboBox.SelectedItem = userProfile.GameMode;
            if (!String.IsNullOrEmpty(userProfile.Status) && !String.IsNullOrWhiteSpace(userProfile.Status))
                ProfileStatusTextBox.Text = userProfile.Status;
            else
                ProfileStatusTextBox.Text = "Status Message";

        }

        /// <summary>
        /// Initialize default profile image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileImage_Initialized(object sender, EventArgs e)
        {
            //ProfileImage.Source = new BitmapImage(new Uri("http://68.media.tumblr.com/78f1e0e0197fc6f0f4f839d0214a7b47/tumblr_o7ww2x2z2A1rsd6nxo4_250.png"));
            ProfileImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/JUSTICE.png"));
        }

        private void TeamJoinRejectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Logs out user and switches back to login page
        /// Changed profile settings should still be preserved if log back in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            PageSwitcher.Switch(new LoginPage());
        }

        /// <summary>
        /// Changes Role preference of logged in User Profile to selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userProfile.Role = (String) RoleComboBox.SelectedItem;
        }

        /// <summary>
        /// Changes Hero preference of logged in User Profile to selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userProfile.Hero = (String) HeroComboBox.SelectedItem;
        }

        /// <summary>
        /// Changes Game Mode preference of logged in User Profile to selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userProfile.GameMode = (String)GameModeComboBox.SelectedItem;
        }

        /// <summary>
        /// Changes Status Message of logged in User Profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileStatusTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ProfileStatusTextBox.Text) && 
                !String.IsNullOrWhiteSpace(ProfileStatusTextBox.Text)
                && !(userProfile == null))
                userProfile.Status = ProfileStatusTextBox.Text;
        }
    }
}
