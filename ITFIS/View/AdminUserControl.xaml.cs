using ITFIS;
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

namespace View
{
    /// <summary>
    /// Interakční logika pro AdminUserControl.xaml
    /// </summary>
    public partial class AdminUserControl : UserControl
    {
        private DatabaseControl databaseControl;
        private AdminCourseControl adminCourseControl;
        public AdminUserControl()
        {
            InitializeComponent();
        }
        public void Init(DatabaseControl databaseControl, AdminCourseControl adminCourseControl)
        {
            this.databaseControl = databaseControl;
            this.adminCourseControl = adminCourseControl;
            userListBox.ItemsSource = this.databaseControl.Users;
        }
        public void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userListBox.SelectedItem != null)
            {
                User u = (User)userListBox.SelectedItem;
                nameLabel.Content = u.Name;
                surnameLabel.Content = u.Surname;
                idLabel.Content = u.Id.ToString();
                roleLabel.Content = databaseControl.Roles[u.RoleId.Value - 1].Title;
            }
            else 
            {
                nameLabel.Content = "";
                surnameLabel.Content = "";
                idLabel.Content = "";
                roleLabel.Content = "";
            }
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            EditUser editUser = new EditUser(databaseControl);
            editUser.ShowDialog();
            userListBox.ItemsSource = databaseControl.Users;
        }

        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedItem != null)
            {
                EditUser editUser = new EditUser(databaseControl, (User)userListBox.SelectedItem);
                editUser.ShowDialog();
                userListBox.ItemsSource = databaseControl.Users;
                userListBox.UnselectAll();
                adminCourseControl.SourceActualisation();
            }
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedItem != null)
            {
                databaseControl.DeleteUser((User)userListBox.SelectedItem);
                userListBox.ItemsSource = databaseControl.Users;
                userListBox.UnselectAll();
            }
        }
    }
}
