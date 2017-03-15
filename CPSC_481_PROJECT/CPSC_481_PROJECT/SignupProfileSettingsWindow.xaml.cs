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
    /// Interaction logic for SignupProfileSettingsWindow.xaml
    /// </summary>
    public partial class SignupProfileSettingsWindow : Window
    {
        public SignupProfileSettingsWindow()
        {
            InitializeComponent();

            //instantiate dropdown lists
            SignupRoleComboBox.ItemsSource = Profile.RolesList;
            SignupHeroComboBox.ItemsSource = Profile.HeroesList;
            SignupGameModeComboBox.ItemsSource = Profile.GameModesList;
        }

        private void SignupProfileSettingsDone_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
