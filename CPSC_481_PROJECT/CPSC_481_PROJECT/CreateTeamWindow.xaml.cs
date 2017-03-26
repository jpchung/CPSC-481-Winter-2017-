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

namespace CPSC_481_PROJECT
{
    /// <summary>
    /// Interaction logic for CreateTeamWindow.xaml
    /// </summary>
    public partial class CreateTeamWindow : Window
    {
        Profile user;
        MainPage userPage;

        public CreateTeamWindow(Profile currentUser, MainPage currentPage)
        {
            InitializeComponent();
            TeameGameModeComboBox.ItemsSource = Profile.GameModesList;
            user = currentUser;

            userPage = currentPage;
           
        }

        private void CreateTeamConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            String newTeamName = TeamNameInput.Text;
            bool existingTeam = false;
            foreach (var team in MainWindow.TeamsList)
            {
                if (team.Key.Equals(newTeamName))
                {
                    existingTeam = true;
                    break;
                }
            }

            if(!existingTeam)
            {
                user.makeNewTeam(newTeamName); //will make new team list with current user as first member
                List<Profile> newTeamList = user.getTeamList();
                MainWindow.TeamsList.Add(newTeamName, newTeamList);
                userPage.GroupSearchStackPanel.Children.Add(new GroupSearchControl(newTeamName));
            }
            

           // if (!user.hasTeam && !String.IsNullOrEmpty(teamName))
           // {


                //userPage.updateProfileTeamPanel();
               // user.hasTeam =  true;

           // }

            Close();
        }
    }
}
