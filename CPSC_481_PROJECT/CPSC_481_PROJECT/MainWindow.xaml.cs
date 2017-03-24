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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Profile> UserList = new List<Profile>();

        /// <summary>
        /// Initialize WPF MainWindow components on start
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Default User Profile List
            Profile defaultProfile = new Profile("birdnukes@gmail.com", "ItsRainingJustice", "cawcaw", "dronestrikes#2016");
            String[] defaultProfileInfo = new String[] { "Offense", "Pharah", "Ranked", "FIRE ZE MISSILES!", "/Images/JUSTICE.png" };
            setDefaultProfileInfo(defaultProfile, defaultProfileInfo);
            defaultProfile.defaultFriends(UserList); //test friend list stackpanel with user list
            defaultProfile.defaultTeam(UserList); //test team list stackpanel with user list
            UserList.Add(defaultProfile);

            defaultProfile = new Profile("peglegpowderkeg@gmail.com", "FireinDaHoe", "cheekynandos", "burningman#1969");
            defaultProfileInfo = new String[] {"Defense", "Junkrat","Quickplay","u wot m8?", "/Images/ARSON.png" };
            setDefaultProfileInfo(defaultProfile, defaultProfileInfo);
            UserList.Add(defaultProfile);

            defaultProfile = new CPSC_481_PROJECT.Profile("grillsgeneration@op.gg", "xX_GurlGamer_Xx", "geegee", "winkyfayce#2014");
            defaultProfileInfo = new String[] {"Defense", "D.Va", "Ranked", "Nerf this!", "/Images/MLG_KPOP_GREMLIN.png"};
            setDefaultProfileInfo(defaultProfile, defaultProfileInfo);
            UserList.Add(defaultProfile);

            //initialize MainWindow to Login page by default
            PageSwitcher.pageSwitchWindow = this;
            PageSwitcher.Switch(new LoginPage());

            
        }

        /// <summary>
        /// Navigate to UserControl page and display contents in MainWindow
        /// </summary>
        /// <param name="nextPage"></param>
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        /// <summary>
        /// set info for default Profiles on startup
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="profileInfo"></param>
        private void setDefaultProfileInfo(Profile profile, String[] profileInfo)
        {
            profile.Role = profileInfo[0];
            profile.Hero = profileInfo[1];
            profile.GameMode = profileInfo[2];
            profile.Status = profileInfo[3];
            profile.ProfileIconSource = profileInfo[4];
        }

        

       
    }
}
