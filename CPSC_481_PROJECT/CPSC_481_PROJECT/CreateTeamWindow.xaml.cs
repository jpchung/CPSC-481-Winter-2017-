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

namespace CPSC_481_PROJECT
{
    /// <summary>
    /// Interaction logic for CreateTeamWindow.xaml
    /// </summary>
    public partial class CreateTeamWindow : Window
    {
        Profile user;
        MainPage userPage;

        /// <summary>
        /// CreateTeamWindow constructor
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="currentPage"></param>
        public CreateTeamWindow(Profile currentUser, MainPage currentPage)
        {
            InitializeComponent();
            TeamGameModeComboBox.ItemsSource = Profile.GameModesList;
            user = currentUser;

            userPage = currentPage;
           
        }

        /// <summary>
        /// Create new team after checking for name input and mode selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTeamConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            String newTeamName = TeamNameInput.Text;

            //check if team already exists (team names unique)
            bool existingTeam = false;
            foreach (var team in MainWindow.TeamsList)
            {
                if (team.Key.Equals(newTeamName))
                {
                    existingTeam = true;
                    break;
                }
            }

            if(!existingTeam && !String.IsNullOrEmpty(newTeamName)
                && !user.hasTeam && TeamGameModeComboBox.SelectedIndex != -1)
            {

                user.makeNewTeam(newTeamName); //will make new team list with current user as first member
                List<Profile> newTeamList = user.getTeamList();
                MainWindow.TeamsList.Add(newTeamName, newTeamList);
                String TeamGameMode = (String) TeamGameModeComboBox.SelectedItem;
             
                //add new team to GroupSearch list
                userPage.GroupSearchStackPanel.Children.Add(new GroupSearchControl(newTeamName, newTeamList));

                userPage.TeamListText.Text = "Team Name: " + newTeamName;

                //update team list on profile tab
                userPage.remakeTeamListPanel();
                Close();

            }


 

        }
    }
}
