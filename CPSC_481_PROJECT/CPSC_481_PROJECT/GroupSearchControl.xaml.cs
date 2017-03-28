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
            int memberCount = 0;
            foreach(Profile member in teamMembers)
            {
                memberCount++;
            }

            switch(memberCount)
            {
                case 1:
                    MemberBorder1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    MemberBorder1.Visibility = Visibility.Visible;
                    MemberBorder2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    MemberBorder1.Visibility = Visibility.Visible;
                    MemberBorder2.Visibility = Visibility.Visible;
                    MemberBorder3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    MemberBorder1.Visibility = Visibility.Visible;
                    MemberBorder2.Visibility = Visibility.Visible;
                    MemberBorder3.Visibility = Visibility.Visible;
                    MemberBorder4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    MemberBorder1.Visibility = Visibility.Visible;
                    MemberBorder2.Visibility = Visibility.Visible;
                    MemberBorder3.Visibility = Visibility.Visible;
                    MemberBorder4.Visibility = Visibility.Visible;
                    MemberBorder5.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
    }
}
