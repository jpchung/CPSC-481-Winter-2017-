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
    /// Interaction logic for ProfileFriendControl.xaml
    /// </summary>
    public partial class ProfileFriendControl : UserControl
    {
        private Profile profile;

        public ProfileFriendControl(Profile friendProfile)
        {
            InitializeComponent();

            //load friend profile details into user control elements 
            profile = friendProfile;
            FriendProfileImage.Source = new BitmapImage(new Uri("pack://application:,,," + profile.ProfileIconSource));
            FriendUsername.Text = profile.getUsernamePassword().Keys.ElementAt(0);
            if (!String.IsNullOrEmpty(profile.Status) && !String.IsNullOrWhiteSpace(profile.Status))
                FriendStatusMessage.Text = profile.Status;
            else
                FriendStatusMessage.Text = "Status Message";

        }
    }
}
