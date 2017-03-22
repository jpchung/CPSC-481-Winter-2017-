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
       /// Initialize MainPage UserControl elements based on user login
       /// </summary>
        public MainPage(int userIndex)
        {
            InitializeComponent();
            
            //instantiate dropdown list items
            RoleComboBox.ItemsSource = SoloSearchRoleComboBox.ItemsSource = Profile.RolesList;
            HeroComboBox.ItemsSource = SoloSearchHeroComboBox.ItemsSource = Profile.HeroesList;
            GameModeComboBox.ItemsSource = Profile.GameModesList;
            
            SoloSearchQuickplayToggle.IsChecked = true;
            GroupSearchQuickplayToggle.IsChecked = true;

            //load logged in User's profile from the UserList
            userProfile = MainWindow.UserList.ElementAt(userIndex);

            //username
            ProfileUsername.Text = userProfile.getUsernamePassword().Keys.ElementAt(0);

            //role/hero/mode selections
            RoleComboBox.SelectedItem = userProfile.Role;
            HeroComboBox.SelectedItem = userProfile.Hero;
            GameModeComboBox.SelectedItem = userProfile.GameMode;

            //profile picture
            ProfileImage.Source = new BitmapImage(new Uri("pack://application:,,," + userProfile.ProfileIconSource));

            //status message
            if (!String.IsNullOrEmpty(userProfile.Status) && !String.IsNullOrWhiteSpace(userProfile.Status))
                ProfileStatusTextBox.Text = userProfile.Status;
            else
                ProfileStatusTextBox.Text = "Status Message";

            //friends list
            List<Profile> ProfileFriendsList = userProfile.getFriendsList();
            if((ProfileFriendsList != null) && ProfileFriendsList.Any())
            {
                foreach(Profile friend in ProfileFriendsList)                
                    FriendsListPanel.Children.Add(new ProfileFriendControl(friend));                
            }

            //team list
            List<Profile> ProfileTeamList = userProfile.getTeamList();
            if((ProfileTeamList != null) && ProfileTeamList.Any())
            {
                foreach (Profile member in ProfileTeamList)
                    TeamListPanel.Children.Add(new ProfileTeamMemberControl(member));
            }
        
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

        /// <summary>
        /// Opens Profile Picture Select Window, then changes image based on icon selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeProfilePicButton_Click(object sender, RoutedEventArgs e)
        {
            new ProfilePictureSelectWindow(userProfile).ShowDialog();
            ProfileImage.Source = new BitmapImage(new Uri("pack://application:,,," + userProfile.ProfileIconSource));
        }
    }
}
