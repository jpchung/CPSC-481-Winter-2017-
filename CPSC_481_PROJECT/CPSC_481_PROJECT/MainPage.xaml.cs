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
                foreach(Profile friendProfile in ProfileFriendsList)                
                    FriendsListPanel.Children.Add(new ProfileFriendControl(userProfile, friendProfile, FriendsListPanel));                
            }

            //team list
            List<Profile> ProfileTeamList = userProfile.getTeamList();
            if((ProfileTeamList != null) && ProfileTeamList.Any())
            {
                foreach (Profile member in ProfileTeamList)
                    TeamListPanel.Children.Add(new ProfileTeamMemberControl(member));
            }

            //list of all users for solo search tab
            foreach(Profile otherProfile in MainWindow.UserList)
                SoloSearchStackPanel.Children.Add(new SoloSearchControl(userProfile, otherProfile));

            SoloSearchQuickplayToggle.IsChecked = true;
            GroupSearchQuickplayToggle.IsChecked = true;

            //list of all teams in team search tab
            //FIX LATER: make actual team list for app
            //foreach (var item in MainWindow.TeamsList)
            //   GroupSearchStackPanel.Children.Add(new GroupSearchControl());


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            foreach(SoloSearchControl user in SoloSearchStackPanel.Children)
            {
                if (user.Equals(userProfile))
                {
                    user.getProfile().Role = userProfile.Role;
                }
            }
        }

        /// <summary>
        /// Changes Hero preference of logged in User Profile to selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userProfile.Hero = (String) HeroComboBox.SelectedItem;

            foreach(SoloSearchControl user in SoloSearchStackPanel.Children)
            {
                if (user.Equals(userProfile))
                {
                    user.getProfile().Hero = userProfile.Hero;
                }
            }
        }

        /// <summary>
        /// Changes Game Mode preference of logged in User Profile to selected item (requires toggle/filter to refresh)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userProfile.GameMode = (String)GameModeComboBox.SelectedItem;

            foreach(SoloSearchControl user in SoloSearchStackPanel.Children)
            {
                if (user.Equals(userProfile))
                {
                    user.getProfile().GameMode = userProfile.GameMode;                  

                }

            }
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

        /// <summary>
        /// Opens Create Team Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTeamButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateTeamWindow(userProfile, this).ShowDialog();

        }


        /// <summary>
        /// Filters users in Solo Search based on Game Mode Toggle (Quickplay)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloSearchQuickplayToggle_Checked(object sender, RoutedEventArgs e)
        {
            //reset role/hero filter menus
            SoloSearchRoleComboBox.SelectedIndex = -1;
            SoloSearchHeroComboBox.SelectedIndex = -1;

            foreach (SoloSearchControl user in SoloSearchStackPanel.Children)
            {
                Profile userProfile = user.getProfile();

                if (userProfile.GameMode.Equals("Quickplay"))
                    user.Visibility = Visibility.Visible;

                else if (userProfile.GameMode.Equals("Ranked"))
                    user.Visibility = Visibility.Collapsed;
                
            }
        }

        /// <summary>
        /// Filters users in Solo Search based on Game Mode Toggle (Ranked)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloSearchRankedToggle_Checked(object sender, RoutedEventArgs e)
        {
            //reset role/hero filter menus
            SoloSearchRoleComboBox.SelectedIndex = -1;
            SoloSearchHeroComboBox.SelectedIndex = -1;

            foreach(SoloSearchControl user in SoloSearchStackPanel.Children)
            {
                Profile profile = user.getProfile();
                if (profile.GameMode.Equals("Ranked"))
                    user.Visibility = Visibility.Visible;

                else if (profile.GameMode.Equals("Quickplay"))
                    user.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Filters users in Solo Search based on Role (filter reset on Game Mode toggle)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloSearchRoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SoloSearchRoleComboBox.SelectedIndex != -1)
            {
                String selectedRole = (String)SoloSearchRoleComboBox.SelectedItem;

                String gameModeToggle = "";
                if (SoloSearchQuickplayToggle.IsChecked == true)
                    gameModeToggle = "Quickplay";
                else if (SoloSearchRankedToggle.IsChecked == true)
                    gameModeToggle = "Ranked";

                String selectedHero = "";
                if (SoloSearchHeroComboBox.SelectedIndex != -1)
                    selectedHero = (String)SoloSearchHeroComboBox.SelectedItem;

                foreach (SoloSearchControl user in SoloSearchStackPanel.Children)
                {
                    Profile profile = user.getProfile();
                    String role = profile.Role;
                    String mode = profile.GameMode;
                    String hero = profile.Hero;
                    if (selectedRole.Equals(role) && gameModeToggle.Equals(mode) && (selectedHero.Equals(hero) || SoloSearchHeroComboBox.SelectedIndex == -1))
                        user.Visibility = Visibility.Visible;
                    else
                        user.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Filters users in Solo Search based on Hero (filter reset on Game Mode toggle)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloSearchHeroComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SoloSearchHeroComboBox.SelectedIndex != -1)
            {
                String selectedHero = (String)SoloSearchHeroComboBox.SelectedItem;

                String gameModeToggle = "";
                if (SoloSearchQuickplayToggle.IsChecked == true)
                    gameModeToggle = "Quickplay";
                else if (SoloSearchRankedToggle.IsChecked == true)
                    gameModeToggle = "Ranked";

                String selectedRole = "";
                if (SoloSearchRoleComboBox.SelectedIndex != -1)
                    selectedRole = (String)SoloSearchRoleComboBox.SelectedItem;


                foreach (SoloSearchControl user in SoloSearchStackPanel.Children)
                {
                    Profile profile = user.getProfile();
                    String role = profile.Role;
                    String mode = profile.GameMode;
                    String hero = profile.Hero;
                    if (selectedHero.Equals(hero) && gameModeToggle.Equals(mode) &&(selectedRole.Equals(role) || SoloSearchRoleComboBox.SelectedIndex == -1))
                        user.Visibility = Visibility.Visible;
                    else
                        user.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
