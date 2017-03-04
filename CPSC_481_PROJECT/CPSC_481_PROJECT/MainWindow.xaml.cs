﻿using System;
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
        /// <summary>
        /// Initialize WPF MainWindow components on start
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
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