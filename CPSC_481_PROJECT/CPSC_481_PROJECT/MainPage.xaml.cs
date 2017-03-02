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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ProfileImage_Initialized(object sender, EventArgs e)
        {
            ProfileImage.Source = new BitmapImage(new Uri("http://68.media.tumblr.com/78f1e0e0197fc6f0f4f839d0214a7b47/tumblr_o7ww2x2z2A1rsd6nxo4_250.png"));
        }
    }
}
