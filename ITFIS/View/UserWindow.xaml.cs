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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interakční logika pro UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private DatabaseControl databaseControl;
        public UserWindow(DatabaseControl databaseControl)
        {
            InitializeComponent();
            this.databaseControl = databaseControl;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (databaseControl.ActiveUser.RoleId == 1)
            {
                userAbout.Init(databaseControl);
                userAboutTab.Visibility = Visibility.Visible;
                adminUser.Init(databaseControl, adminCourse);
                adminUserTab.Visibility = Visibility.Visible;
                adminCourse.Init(databaseControl, lectorOverview);
                adminCourseTab.Visibility = Visibility.Visible;
            }
            else if (databaseControl.ActiveUser.RoleId == 2)
            {
                userAbout.Init(databaseControl);
                userAboutTab.Visibility = Visibility.Visible;
                lectorOverview.Init(databaseControl);
                lectorOverviewTab.Visibility = Visibility.Visible;
                adminCourse.Init(databaseControl, lectorOverview);
                adminCourseTab.Visibility = Visibility.Visible;
            }
            else if (databaseControl.ActiveUser.RoleId == 3)
            {
                userAbout.Init(databaseControl);
                userAboutTab.Visibility = Visibility.Visible;
                userRegistration.Init(databaseControl, userOverview);
                userRegistrationTab.Visibility = Visibility.Visible;
                userOverview.Init(databaseControl);
                userOverviewTab.Visibility = Visibility.Visible;                
            }
        }
    }
}
