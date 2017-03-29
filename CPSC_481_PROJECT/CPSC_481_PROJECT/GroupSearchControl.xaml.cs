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
                switch(teamMembers.IndexOf(member) + 1)
                {
                    case 1:
                        MemberBorder1.Visibility = MemberName1.Visibility = Visibility.Visible;
                        MemberName1.Text = member.getUsernamePassword().Keys.ElementAt(0);
                        if (MemberName1.Text.Length >= 15)
                            MemberName1.Margin = new Thickness(270, 120, 0, 0);

                        break;
                    case 2:                      
                        MemberBorder2.Visibility = MemberName2.Visibility = Visibility.Visible;
                        MemberName2.Text = member.getUsernamePassword().Keys.ElementAt(0);
                        break;
                    case 3:
                        MemberBorder3.Visibility = MemberName3.Visibility = Visibility.Visible;
                        MemberName3.Text = member.getUsernamePassword().Keys.ElementAt(0);
                        break;
                    case 4:
                        MemberBorder4.Visibility = MemberName4.Visibility = Visibility.Visible;
                        MemberName4.Text = member.getUsernamePassword().Keys.ElementAt(0);
                        break;
                    case 5:                      
                        MemberBorder5.Visibility = MemberName5.Visibility = Visibility.Visible;
                        MemberName5.Text = member.getUsernamePassword().Keys.ElementAt(0);
                        break;
                    default:
                        break;
                }
                
            }

            

            
        }
    }
}
