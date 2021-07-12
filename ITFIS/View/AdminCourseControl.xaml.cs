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
    /// Interakční logika pro AdminCourseControl.xaml
    /// </summary>
    public partial class AdminCourseControl : UserControl
    {
        private DatabaseControl databaseControl;
        private LectorOverview lectorOverview;
        public AdminCourseControl()
        {
            InitializeComponent();
        }
        public void Init(DatabaseControl databaseControl, LectorOverview lectorOverview)
        {
            this.databaseControl = databaseControl;
            DataContext = this.databaseControl;
            courseListBox.ItemsSource = databaseControl.Courses;
            this.lectorOverview = lectorOverview;
        }

        public void SourceActualisation()
        {
            courseListBox.UnselectAll();
        }

        private void changeCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseListBox.SelectedItem != null)
            {
                if ((((Course)courseListBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    EditCourse editCourse = new EditCourse(databaseControl, (Course)courseListBox.SelectedItem);
                    editCourse.ShowDialog();
                    courseListBox.UnselectAll();
                    courseListBox.ItemsSource = databaseControl.Courses;
                    lectorOverview.SourceActualisation();
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void addCourseButton_Click(object sender, RoutedEventArgs e)
        {
            EditCourse editCourse = new EditCourse(databaseControl);
            editCourse.ShowDialog();
            courseListBox.ItemsSource = databaseControl.Courses;
        }

        private void deleteCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Course)courseListBox.SelectedItem != null)
            {
                if ((((Course)courseListBox.SelectedItem).LectorId == databaseControl.ActiveUser.Id) || (databaseControl.ActiveUser.RoleId == 1))
                {
                    databaseControl.DeleteCourse((Course)courseListBox.SelectedItem);
                    courseListBox.ItemsSource = databaseControl.Courses;
                    lectorOverview.SourceActualisation();
                }
                else
                {
                    MessageBox.Show("Nemáte oprávnění upravit tento kurz!", "Chyba!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                nameLabel.Content = "";
                lectorLabel.Content = "";
                capacityrLabel.Content = "";
                descriptionTextBox.Text = "";
            }
        }

        private void courseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Course)courseListBox.SelectedItem != null)
            {
                Course course = (Course)courseListBox.SelectedItem;
                nameLabel.Content = course.Title;
                lectorLabel.Content = databaseControl.FindUser(course.LectorId.Value);
                capacityrLabel.Content = course.Capacity.ToString();
                descriptionTextBox.Text = course.Description.Trim();
            }
            else
            {
                nameLabel.Content = "";
                lectorLabel.Content = "";
                capacityrLabel.Content = "";
                descriptionTextBox.Text = "";
            }
        }
    }
}
