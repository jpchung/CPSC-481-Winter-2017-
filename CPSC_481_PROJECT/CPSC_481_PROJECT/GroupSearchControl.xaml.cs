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
    /// Interaction logic for GroupSearchControl.xaml
    /// </summary>
    public partial class GroupSearchControl : UserControl
    {
        public GroupSearchControl(String teamName, List<Profile> teamMembers)
        {
            InitializeComponent();
            TeamSearchName.Text = teamName;

            //WIP - instatiate only as many images/borders as there are members
            foreach(Profile member in teamMembers)
            {

            }

        }
    }
}
