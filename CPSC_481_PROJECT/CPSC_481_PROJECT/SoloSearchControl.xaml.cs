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
    /// Interaction logic for SoloSearchControl.xaml
    /// </summary>
    public partial class SoloSearchControl : UserControl
    {
        private Profile currentUser, otherUser;

        public SoloSearchControl(Profile currentProfile, Profile otherProfile)
        {
            InitializeComponent();

            //Profile of current logged in user
            currentUser = currentProfile;

            //load profile details of other user to UserControl elements
            otherUser = otherProfile;
            SoloSearchProfileImage.Source = new BitmapImage(new Uri("pack://application:,,," + otherUser.ProfileIconSource));
            SoloSearchUsername.Text = otherUser.getUsernamePassword().Keys.ElementAt(0);

            String roleIconSource;
            switch (otherUser.Role)
            {
                case "Offense":
                    roleIconSource = "/Images/OffenseIcon.png";
                    break;
                case "Defense":
                    roleIconSource = "/Images/DefenseIcon.png";
                    break;
                case "Tank":
                    roleIconSource = "/Images/TankIcon.png";
                    break;
                case "Support":                    
                default:
                    roleIconSource = "/Images/SupportIcon.png";
                    break;
            }
            SoloSearchRoleIcon.Source = new BitmapImage(new Uri("pack://application:,,," + roleIconSource));
        }
    }
}
