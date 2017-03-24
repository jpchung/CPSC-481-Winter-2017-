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

            //load role icon based on profile settings
            String roleIconSource;
            switch (otherUser.Role)
            {
                case "Offense":
                    roleIconSource = "OffenseIcon.png";
                    break;
                case "Defense":
                    roleIconSource = "DefenseIcon.png";
                    break;
                case "Tank":
                    roleIconSource = "TankIcon.png";
                    break;
                case "Support":                    
                default:
                    roleIconSource = "SupportIcon.png";
                    break;
            }
            SoloSearchRoleIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Images/" + roleIconSource));

            //load hero icon based on profile settings
            String HeroIconSource;          
            switch(otherUser.Hero)
            {
                case "Ana":
                    HeroIconSource = "ana.png";
                    break;
                case "Bastion":

                    HeroIconSource = "bastion.png";
                    break;
                case "D.Va":

                    HeroIconSource = "dva.png";
                    break;
                case "Genji":
                    HeroIconSource = "genji.png";
                    break;
                case "Hanzo":
                    HeroIconSource = "hanzo.png";
                    break;
                case "Junkrat":
                    HeroIconSource = "junkrat.png";
                    break;
                case "Lucio":
                    HeroIconSource = "lucio.png";
                    break;
                case "McCree":
                    HeroIconSource = "mccree.png";
                    break;
                case "Mei":
                    HeroIconSource = "mei.png";
                    break;
                case "Mercy":
                    HeroIconSource = "mercy.png";
                    break;
                case "Orisa":
                    HeroIconSource = "orisa.png";
                    break;
                case "Pharah":
                    HeroIconSource = "pharah.png";
                    break;
                case "Reaper":
                    HeroIconSource = "reaper.png";
                    break;
                case "Reinhardt":
                    HeroIconSource = "reinhardt.png";
                    break;
                case "Roadhog":
                    HeroIconSource = "roadhog.png";
                    break;
                case "Soldier: 76":
                    HeroIconSource = "soldier76.png";
                    break;
                case "Sombra":
                    HeroIconSource = "sombra.png";
                    break;
                case "Symmetra":
                    HeroIconSource = "symmetra.png";
                    break;
                case "Torbjorn":
                    HeroIconSource = "torbjorn.png";
                    break;
                case "Tracer":
                    HeroIconSource = "tracer.png";
                    break;
                case "Widowmaker":
                    HeroIconSource = "widowmaker.png";
                    break;
                case "Winston":
                    HeroIconSource = "winston.png";
                    break;
                case "Zarya":
                    HeroIconSource = "zarya.png";
                    break;
                case "Zenyatta":                   
                default:
                    HeroIconSource = "zenyatta.png";
                    break;
            }
            SoloSearchHeroImage.Source = new BitmapImage(new Uri("pack://application:,,,/HeroIcons/" + HeroIconSource));
            SoloSearchHeroName.Text = otherUser.Hero;

        }
    }
}
