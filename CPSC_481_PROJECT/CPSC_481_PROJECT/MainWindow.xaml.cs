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

            //User Profile List
            UserList.Add(new Profile("birdnukes@gmail.com", "itsrainingjustice", "cawcaw", "dronestrikes#2016"));
            UserList.Add(new Profile("peglegpowderkeg@gmail.com","fireindahoe","cheekynandos","burningman#1969"));

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
    }
}
